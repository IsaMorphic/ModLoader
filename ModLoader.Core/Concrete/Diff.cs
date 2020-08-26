using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
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

    public class Hunk : Xunk<Hunk>
    {
        public List<Line> Lines { get; }
        public override long Offset { get; }

        public override long Length => Lines.Aggregate(0, (c, l) => l.Op == Operation.Add ? c + 1 : c - 1);

        public Hunk(Diff parent, List<Line> lines, int offset) : base(parent)
        {
            Lines = lines;
            Offset = offset;

            Enabled = true;
        }

        public override Hunk ResolveSelf() => this;

        public override string[] GetDisplayText()
        {
            List<string> lines = new List<string>();
            lines.Add($"Starting at line {Offset + 1}:");

            foreach (var line in Lines)
            {
                lines.Add($"{(line.Op == Operation.Add ? "+" : "-")} {line.Text}");
            }

            return lines.ToArray();
        }

        public override string ToString()
        {
            return $"HUNK;[offset:{Offset},length:{Length}]";
        }
    }

    public class Diff : XunkGroup<Hunk>
    {
        public class DiffLoader : IXunkGroupLoader<Hunk>
        {
            public async Task LoadAsync(XunkGroup<Hunk> group, CancellationToken token)
            {
                if (group.Root.Graph.Table[group.Name].Contains(group.Id)) return;

                List<long> indicies = new List<long>();
                List<string> lines = new List<string>();

                var path = Path.Combine(group.Root.GamePath, group.Name);
                using (var stream = File.OpenRead(path))
                using (var reader = new StreamReader(stream))
                {
                    int index = 0;
                    while (!reader.EndOfStream)
                    {
                        lines.Add(await reader.ReadLineAsync());
                        indicies.Add(index++);
                    }
                }

                foreach (var hunk in group.Members.Select(m => m.Resolve()))
                {
                    int index = indicies.IndexOf(hunk.Offset);
                    foreach (var line in hunk.Lines)
                    {
                        switch (line.Op)
                        {
                            case Operation.Remove:
                                lines.RemoveAt(index);
                                indicies.RemoveAt(index);
                                break;

                            case Operation.Add:
                                lines.Insert(index, line.Text);
                                indicies.Insert(index, index);
                                index++;
                                break;
                        }
                    }
                }

                using (var stream = File.Create(path))
                using (var writer = new StreamWriter(stream))
                {
                    foreach (var line in lines)
                    {
                        await writer.WriteLineAsync(line);
                    }
                }

                group.Root.Graph.Table[group.Name].Add(group.Id);
            }
        }

        public Diff(Pack parent, string name, Guid id) : base(parent, name, id, new DiffLoader())
        {
            using (var data = GetDataStream())
            using (var reader = new StreamReader(data))
            {
                string line = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    if (!line.StartsWith(": ") || !int.TryParse(line.Remove(0, 2), out int offset))
                        throw new FormatException("Bad hunk format! Check your syntax or contact pack developer to resolve the issue.");

                    List<Line> lines = new List<Line>();

                    line = reader.ReadLine();

                    while (!line.StartsWith(": "))
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
                        else
                        {
                            throw new FormatException("Diff parse failed! Bad hunk format. Check your syntax or contact pack developer to resolve the issue.");
                        }

                        if (reader.EndOfStream)
                            break;

                        line = reader.ReadLine();
                    }

                    var hunk = new Hunk(this, lines, offset);

                    var conflictors = Members
                            .Select(h => h.Resolve())
                            .Where(h => h.CanMergeWith(hunk));

                    if (conflictors.Any())
                    {
                        var conflict = new Conflict<Hunk>(hunk.ToString(), hunk, new HashSet<Hunk>(conflictors));
                        throw new ConflictException<Hunk>("Diff parse failed! Diff cannot have conflicting hunks. Contact the developer of this pack to resolve the issue.", conflict);
                    }
                    else
                    {
                        Members.Add(hunk);
                    }
                }
            }
        }

        public override Stream GetDataStream()
        {
            return Parent.Archive.GetEntry($"{Name}.diff").Open();
        }
    }
}
