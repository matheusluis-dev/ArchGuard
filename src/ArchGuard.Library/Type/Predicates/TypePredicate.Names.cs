namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using ArchGuard.Library.Extensions.Type;

    internal static partial class TypePredicate
    {
        internal static Func<Type, StringComparison, bool> HaveName(string name)
        {
            return (type, comparison) => type.GetNameClean().Equals(name, comparison);
        }

        internal static Func<Type, StringComparison, bool> HaveFullName(string name)
        {
            return (type, comparison) => type.GetFullNameClean().Equals(name, comparison);
        }

        internal static Func<Type, StringComparison, bool> HaveNameStartingWith(string name)
        {
            return (type, comparison) => type.GetNameClean().StartsWith(name, comparison);
        }

        internal static Func<Type, StringComparison, bool> HaveNameEndingWith(string name)
        {
            return (type, comparison) => type.GetNameClean().EndsWith(name, comparison);
        }
    }
}
