namespace ModLoader.Core.Abstract
{
    public class PrioritizedXunkGroup<T> : Prioritized<Module>
        where T : Xunk<T>
    {
        public PrioritizedXunkGroup(IMergeable<Module> inner, int priority) : base(inner, priority)
        {
        }


    }
}
