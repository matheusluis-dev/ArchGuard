namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using System.Linq;
    using ArchGuard.Library.Extensions;
    using ArchGuard.Library.Extensions.Type;

    internal static partial class TypePredicate
    {
        internal static Func<Type, StringComparison, bool> HaveName(params string[] name)
        {
            return (type, comparison) =>
                name.Contains(type.GetNameClean(), comparison.ToComparer());
        }

        internal static Func<Type, StringComparison, bool> HaveFullName(params string[] name)
        {
            return (type, comparison) =>
                name.Contains(type.GetFullNameClean(), comparison.ToComparer());
        }

        internal static Func<Type, StringComparison, bool> HaveNameStartingWith(
            params string[] name
        )
        {
            return (type, comparison) =>
                name.Any(n => type.GetNameClean().StartsWith(n, comparison));
        }

        internal static Func<Type, StringComparison, bool> HaveNameEndingWith(params string[] name)
        {
            return (type, comparison) => name.Any(n => type.GetNameClean().EndsWith(n, comparison));
        }
    }
}
