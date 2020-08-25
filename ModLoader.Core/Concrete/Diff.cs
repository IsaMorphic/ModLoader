using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ModLoader.Core
{
    using Abstract;
    using Filters;
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

    public class Hunk : IMergeable<Hunk>
    {
        public List<Line> Lines { get; }
        public int StartOffset { get; }

        public IResolvable<Hunk> Fallback => null;
        public bool Enabled { get; set; }

        public Hunk(List<Line> lines, int startOffset)
        {
            Lines = lines;
            StartOffset = startOffset;

            Enabled = true;
        }

        public bool CanMergeWith(Hunk other)
        {
            int otherLength = other.Lines.Aggregate(0, (c, l) => l.Op == Operation.Add ? c + 1 : c - 1);
            return StartOffset >= other.StartOffset && other.StartOffset + otherLength >= StartOffset;
        }

        public IResolvable<Hunk> MergeWith(HashSet<Hunk> others)
        {
            return new Conflict<Hunk>(this, others);
        }

        public Hunk ResolveSelf() => this;
    }

    public class ResolvingDiff : Diff
    {
        public IResolvable<IGroup<Hunk>> Resolver { get; }

        public ResolvingDiff(Pack parent, string name, IResolvable<IGroup<Hunk>> resolver) : base(parent, name, Guid.Empty)
        {
            Resolver = resolver;
        }

        public override Module ResolveSelf()
        {
            return new Diff(Parent, Name, Resolver.Resolve().Members);
        }

        public override string ToString()
        {
            return "(MERGED DIFF)";
        }
    }

    public class Diff : Module, IGroup<Hunk>
    {
        public HashSet<IResolvable<Hunk>> Members { get; }

        public Diff(Pack parent, string name, Guid id) : base(parent, name, id)
        {
            Members = new HashSet<IResolvable<Hunk>>();

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

                    var hunk = new Hunk(lines, offset);

                    var conflictors = Members
                            .Select(h => h.ResolveSelf())
                            .Where(h => h.CanMergeWith(hunk));

                    if (conflictors.Any())
                    {
                        var conflict = new Conflict<Hunk>(hunk, new HashSet<Hunk>(conflictors));
                        throw new ConflictException<Hunk>("Diff parse failed! Diff cannot have conflicting hunks. Contact the developer of this pack to resolve the issue.", conflict);
                    }
                    else
                    {
                        Members.Add(hunk);
                    }
                }
            }
        }

        public Diff(Pack parent, string name, HashSet<IResolvable<Hunk>> hunks) : base(parent, name, Guid.Empty)
        {
            Members = hunks;
        }

        public override Stream GetDataStream()
        {
            return Parent.Archive.GetEntry($"{Name}.diff").Open();
        }

        public override IResolvable<Module> MergeWith(HashSet<Module> others)
        {
            if (others.All(m => m is Diff))
            {
                var otherGroups = new HashSet<IGroup<Hunk>>(
                    others.Cast<IGroup<Hunk>>());

                otherGroups.Add(this);

                return new ResolvingDiff(Parent, Name,
                    new MergeFilter<Hunk>()
                    {
                        Fallback = new GroupMerger<Hunk>(otherGroups)
                    });
            }
            else
            {
                return base.MergeWith(others);
            }
        }

        public override async Task LoadSelfAsync(CancellationToken token)
        {
            if (Root.Graph.Table[Name].Contains(Id)) return;

            List<int> indicies = new List<int>();
            List<string> lines = new List<string>();

            var path = Path.Combine(Root.GamePath, Name);
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

            foreach (var hunk in Members.Select(m => m.ResolveSelf()))
            {
                int index = indicies.IndexOf(hunk.StartOffset);
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

            Root.Graph.Table[Name].Add(Id);
        }
    }
}
