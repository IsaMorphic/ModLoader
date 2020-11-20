using System.Collections.Generic;

namespace ModLoader.Core.Abstract
{
    public interface IResolvable<out T> : IPotential<T>
        where T : class
    {
        IResolvable<T> Fallback { get; }
        bool Enabled { get; }
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

        public static List<IResolvable<T>> ResolveFull<T>(this IResolvable<T> unit, bool inclusive = true)
            where T : class
        {
            var list = new List<IResolvable<T>>();
            if (unit.Enabled && inclusive) list.Add(unit);
            return unit.ResolveFull(list);
        }

        public static List<IResolvable<T>> ResolveFull<T>(this IResolvable<T> unit, List<IResolvable<T>> list)
            where T : class
        {
            var next = unit.Fallback;
            if (next?.Enabled ?? false)
            {
                list.Add(next);
                return next.ResolveFull(list);
            }
            else
            {
                return list;
            }
        }
    }
}
