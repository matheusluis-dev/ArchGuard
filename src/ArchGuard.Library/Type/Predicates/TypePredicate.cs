namespace ArchGuard.Library.Type.Predicates
{
    using System;

    internal static partial class TypePredicate
    {
        internal static Func<Type, bool> AreOfType(Type typeParam)
        {
            return type => type == typeParam;
        }
    }
}
