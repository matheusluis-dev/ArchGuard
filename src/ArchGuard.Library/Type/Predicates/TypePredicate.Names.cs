namespace ArchGuard.Library.Type.Predicates
{
    using System;

    internal static partial class TypePredicate
    {
        internal static Func<Type, bool> HaveNameStartingWith(
            string name,
            StringComparison comparison
        )
        {
            return type => type.Name.StartsWith(name, comparison);
        }

        internal static Func<Type, bool> HaveNameEndingWith(
            string name,
            StringComparison comparison
        )
        {
            return type => type.Name.EndsWith(name, comparison);
        }
    }
}
