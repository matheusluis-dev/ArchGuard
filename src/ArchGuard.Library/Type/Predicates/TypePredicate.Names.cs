namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using ArchGuard.Library.Extensions.Type;

    internal static partial class TypePredicate
    {
        internal static Func<Type, bool> HaveName(string name, StringComparison comparison)
        {
            return type => type.GetNameClean().Equals(name, comparison);
        }

        internal static Func<Type, bool> HaveFullName(string name, StringComparison comparison)
        {
            return type => type.GetFullNameClean().Equals(name, comparison);
        }

        internal static Func<Type, bool> HaveNameStartingWith(
            string name,
            StringComparison comparison
        )
        {
            return type => type.GetNameClean().StartsWith(name, comparison);
        }

        internal static Func<Type, bool> HaveNameEndingWith(
            string name,
            StringComparison comparison
        )
        {
            return type => type.GetNameClean().EndsWith(name, comparison);
        }
    }
}
