using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ModLoader.Core.Concrete
{
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

    public class Hunk : Unit<Hunk>
    {
        public Diff Parent { get; }

        public (int start, int end) Range { get; }
        public List<Line> Lines { get; }

        public Hunk(Diff parent, (int start, int end) range, List<Line> lines) : base("_none_")
        {
            Parent = parent;

            Range = range;
            Lines = lines;
        }

        public override bool CanMergeWith(Hunk other)
        {
            throw new NotImplementedException();
        }

        public override Merger<Hunk> MergeWith(HashSet<Hunk> others)
        {
            throw new NotImplementedException();
        }

        protected override Hunk ResolveSelf() => this;

        protected override Task LoadSelfAsync()
        {
            throw new NotImplementedException();
        }
    }

    public class Diff : Group<Module, Hunk>
    {
        public Module Base { get; }

        public Diff(Module @base) : base(@base.Name, new HashSet<Unit<Hunk>>())
        {
        }

        public override bool CanMergeWith(Module other)
        {
            throw new NotImplementedException();
        }

        public override Merger<Module> MergeWith(HashSet<Module> others)
        {
            throw new NotImplementedException();
        }

        protected override Module ResolveSelf()
        {
            throw new NotImplementedException();
        }

        protected override Task LoadSelfAsync()
        {
            throw new NotImplementedException();
        }
    }
}
