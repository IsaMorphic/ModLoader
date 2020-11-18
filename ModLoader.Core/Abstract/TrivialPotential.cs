namespace ModLoader.Core.Abstract
{
    public class TrivialPotential<T> : IPotential<T>
        where T : class
    {
        private T Inner { get; }

        public TrivialPotential(T inner)
        {
            Inner = inner;
        }

        public T ResolveSelf()
        {
            return Inner;
        }
    }
}
