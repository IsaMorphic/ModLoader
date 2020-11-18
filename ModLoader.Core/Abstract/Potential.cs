namespace ModLoader.Core.Abstract
{
    public interface IPotential<out T>
        where T : class
    {
        T ResolveSelf();
    }
}
