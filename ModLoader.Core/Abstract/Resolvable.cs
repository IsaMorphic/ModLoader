using System.Collections.Generic;

namespace ModLoader.Core.Abstract
{
    public interface IResolvable<T>
        where T : class
    {
        IResolvable<T> Fallback { get; }
        bool Enabled { get; }

        T ResolveSelf();
    }

    public static class ResolvableExtensions
    {
        public static T Resolve<T>(this IResolvable<T> unit)
            where T : class
        {
            return unit.Enabled ? unit.ResolveSelf() : unit.Fallback?.Resolve();
        }

        public static T ResolveAsIfDisabled<T>(this IResolvable<T> unit)
            where T : class
        {
            return unit.Fallback?.Resolve();
        }

        public static List<IResolvable<T>> ResolveFull<T>(this IResolvable<T> unit)
            where T : class, IResolvable<T>
        {
            return unit.ResolveFull(new List<IResolvable<T>>());
        }

        public static List<IResolvable<T>> ResolveFull<T>(this IResolvable<T> unit, List<IResolvable<T>> list)
            where T : class, IResolvable<T>
        {
            var next = unit.ResolveAsIfDisabled();
            list.Add(next);
            return unit.Fallback?.ResolveFull(list) ?? list;
        }
    }
}
