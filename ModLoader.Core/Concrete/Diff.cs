using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    using Abstract;
    using Exceptions;

    public enum Operation
    {
        Remove,
        Add,
    }

    public class Line
    {
        public string Text { get; }
        public Operation Op { get; }

        public Line(string text, Operation op)
        {
            Text = text;
            Op = op;
        }
    }

    public class Hunk : Xunk<Hunk>, IExceptional
    {
        public List<Line> Lines { get; }

        public override long Offset { get; }
        public override long Length => Lines.Aggregate(0, (c, l) => l.Op == Operation.Remove ? c + 1 : c);

        public HashSet<Exception> Errors { get; }

        public Hunk(Diff parent, List<Line> lines, int offset, HashSet<Exception> errors) : base(parent)
        {
            Lines = lines;
            Offset = offset;

            Errors = errors;
        }

        public override Hunk ResolveSelf() => this;

        public override string[] GetDisplayText()
        {
            if (Errors.Any())
            {
                return Errors.SelectMany(err => (err.Message + '\n').Split('\n')).ToArray();
            }
            else
            {
                List<string> lines = new List<string>();
                lines.Add($"Starting at line {Offset + 1}:");

                foreach (var line in Lines)
                {
                    lines.Add($"{(line.Op == Operation.Add ? "+" : (line.Op == Operation.Remove ? "-" : ">"))} {line.Text}");
                }

                return lines.ToArray();
            }
        }

        public override string ToString()
        {
            return (Errors.Any() ? "[ERROR] " : "") + $"HUNK;[offset:{Offset},length:{Length}]";
        }
    }

    public class Diff : XunkGroup<Hunk>
    {
        public class DiffLoader : IXunkLoader<Hunk>
        {
            public async Task LoadAsync(XunkGroup<Hunk> group)
            {
                if (group.Root.Graph.Table.ContainsKey(group.Name) && group.Root.Graph.Table[group.Name] == group.Id) return;

                List<string> lines = new List<string>();
                List<long> indicies = new List<long>();

                int i = 0;

                using (var stream = group.Base.GetDataStream())
                using (var reader = new StreamReader(stream))
                {
                    string line = await reader.ReadLineAsync();
                    while (line != null)
                    {
                        lines.Add(line);
                        indicies.Add(i++);
                        line = await reader.ReadLineAsync();
                    }
                    lines.Add("");
                    indicies.Add(i++);
                }

                foreach (var hunk in group.Xunks
                    .Select(m => m is IResolvable<Hunk> ? m.ResolveSelf() : m.ResolveSelf())
                    .Where(m => m != null)
                    .OrderBy(m => m.Offset))
                {
                    int index = indicies.LastIndexOf(hunk.Offset);
                    foreach (var line in hunk.Lines)
                    {
                        switch (line.Op)
                        {
                            case Operation.Remove:
                                try
                                {
                                    lines.RemoveAt(index);
                                    indicies.RemoveAt(index);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    throw new ArgumentOutOfRangeException($"An error occured while loading diff module.\nThe most likely cause is that the user created a diff that removes more lines than there are in the base file.\nOffending module: {group}");
                                }
                                break;
                            case Operation.Add:
                                lines.Insert(index, line.Text);
                                indicies.Insert(index, index);
                                index++;
                                break;
                        }
                    }
                }

                var file = await group.Root.Files.StageFileAsync(group.Name);
                var writer = new StreamWriter(file.Stream);
                foreach (var line in lines)
                {
                    await writer.WriteLineAsync(line);
                }

                await writer.FlushAsync();

                try
                {
                    await group.Root.BasePack.CopyModuleAsync(group.Name);

                    await group.Root.Files.CommitFileAsync(file);

                    if (group.Root.Graph.Table.ContainsKey(group.Name))
                        group.Root.Graph.Table[group.Name] = group.Id;
                    else
                        group.Root.Graph.Table.Add(group.Name, group.Id);
                }
                catch (Exception)
                {
                    await group.Root.Files.UnstageFileAsync(file);
                    throw;
                }
            }
        }

        static Diff()
        {
            XunkLoader.Loaders.Add(typeof(Hunk), new DiffLoader());
        }

        public Diff(Pack parent, string name, Guid id) : base(parent, name, id)
        {
        }

        public async Task InitializeAsync()
        {
            List<string> baseText = new List<string>();

            using (var stream = Base.GetDataStream())
            using (var reader = new StreamReader(stream))
            {
                string line = await reader.ReadLineAsync();
                while (line != null)
                {
                    baseText.Add(line);
                    line = await reader.ReadLineAsync();
                }
                baseText.Add("");
            }

            using (var data = GetDataStream())
            using (var reader = new StreamReader(data))
            {
                string line = await reader.ReadLineAsync();
                while (line != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        line = await reader.ReadLineAsync();
                        continue;
                    }

                    HashSet<Exception> errors = new HashSet<Exception>();

                    bool validIdxLine = int.TryParse(line.Remove(0, 2), out int offset) && line.StartsWith(": ");
                    bool validSearchLine = !string.IsNullOrWhiteSpace(line.Remove(0, 2)) && line.StartsWith("= ");

                    if (offset < 0)
                        offset = baseText.Count + offset;

                    if (!validIdxLine)
                    {
                        if (validSearchLine)
                        {
                            var str = line.Remove(0, 2);
                            try
                            {
                                offset = baseText
                                    .Select((s, i) => (s, i))
                                    .First(x => x.s.StartsWith(str)).i;
                            }
                            catch (InvalidOperationException)
                            {
                                errors.Add(new FormatException($"Could not find \"{str}\" in _base_ version of module.\nOffending line: \"{line}\"\nOffending module: {this}"));
                                offset = -1;
                            }
                        }
                        else
                        {
                            errors.Add(new FormatException($"Invalid hunk header. Expecting a line starting with: \": <line number>\" or \"= <search string>\".\nOffending line: \"{line}\"\nOffending module: {this}"));
                        }
                    }
                    else if (offset < 0 || offset > baseText.Count - 1)
                    {
                        errors.Add(new FormatException($"Line offset \"{offset}\" is out of the file's bounds.\nOffending line: \"{line}\"\nOffending module: {this}"));
                    }

                    List<Line> lines = new List<Line>();

                    line = await reader.ReadLineAsync();

                    while (line != null && !line.StartsWith(": ") && !line.StartsWith("= "))
                    {
                        if (line.StartsWith("+ "))
                        {
                            lines.Add(new Line(line.Remove(0, 2), Operation.Add));
                        }
                        else if (line.StartsWith("+"))
                        {
                            lines.Add(new Line("", Operation.Add));
                        }
                        else if (line.StartsWith("-"))
                        {
                            lines.Add(new Line("", Operation.Remove));
                        }
                        else if (line.StartsWith("| "))
                        {
                            lines.Add(new Line("", Operation.Remove));
                            lines.Add(new Line(line.Remove(0, 2), Operation.Add));
                        }
                        else if (line.StartsWith("> "))
                        {
                            if (lines.Any())
                                errors.Add(new FormatException($"If a hunk has a \">\" line present, it must be the only line in the hunk. Bogus? Maybe. Ask Yoda and Polly, but do so at your own risk...\nOffending line: \"{line}\"\nOffending module: {this}"));
                            else
                            {
                                lines.Add(new Line("", Operation.Remove));
                                lines.Add(new Line(baseText[offset] + line.Remove(0, 2), Operation.Add));
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(line))
                        {
                            errors.Add(new FormatException($"Expected line starting with \"+\", \"-\", \"|\", or \">\".\nOffending line: \"{line}\"\nOffending module: {this}"));
                        }

                        if (line == null)
                            break;

                        line = await reader.ReadLineAsync();
                    }

                    var hunk = new Hunk(this, lines, offset, errors);

                    if (Xunks.Select(h => h.ResolveSelf())
                        .Any(h => h.CanMergeWith(hunk) || hunk.CanMergeWith(h)))
                        hunk.Errors.Add(new ConflictException<Hunk>($"This hunk conflicts with a hunk in this diff that was parsed prior.\nOffending module: {this}"));

                    Xunks.Add(hunk);
                }
            }
        }

        public override Stream GetDataStream()
        {
            return Parent.GetStream($"{Name}.diff");
        }
    }
}
