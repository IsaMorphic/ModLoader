using System;
using System.Collections.Generic;
using System.Linq;

namespace ModLoader.Core
{
    using Abstract;
    using Filters;

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
        }

        public bool CanMergeWith(Hunk other)
        {
            return StartOffset >= other.StartOffset && other.StartOffset + other.Lines.Count >= StartOffset;
        }

        public IResolvable<Hunk> MergeWith(HashSet<Hunk> others)
        {
            return new Conflict<Hunk>(this, others);
        }

        public Hunk ResolveSelf() => this;
    }

    public class DiffResolver : IResolvable<Module>
    {
        public IResolvable<IGroup<Hunk>> Resolver { get; }

        public IResolvable<Module> Fallback { get; }
        public bool Enabled { get; }

        public DiffResolver(IResolvable<IGroup<Hunk>> resolver)
        {
            Resolver = resolver;
        }

        public Module ResolveSelf()
        {
            return new Diff(Resolver.Resolve().Members);
        }
    }

    public class Diff : Module, IGroup<Hunk>
    {
        public HashSet<IResolvable<Hunk>> Members { get; }

        public Diff(Pack parent, string name, Guid id) : base(parent, name, id)
        {
            Members = new HashSet<IResolvable<Hunk>>();
        }

        public Diff(HashSet<IResolvable<Hunk>> hunks) : this(null, null, Guid.Empty)
        {
            Members = hunks;
        }

        public override IResolvable<Module> MergeWith(HashSet<Module> others)
        {
            if (others.All(m => m is Diff))
            {
                var otherGroups = new HashSet<IGroup<Hunk>>(
                    others.Cast<IGroup<Hunk>>());

                return new DiffResolver(
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
    }
}
