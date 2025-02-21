namespace ArchGuard.Tests.Common.Types
{
    public static partial class TypeNames
    {
        public static class Nested
        {
            public const string PublicNonNestedClass = Namespaces.Nested + "." + nameof(PublicNonNestedClass);

            public const string PublicParentClass = Namespaces.Nested + "." + nameof(PublicParentClass);

            public const string PublicNestedClass = PublicParentClass + "+" + nameof(PublicNestedClass);

            public const string PrivateNestedClass = PublicParentClass + "+" + nameof(PrivateNestedClass);

            public const string ProtectedNestedClass = PublicParentClass + "+" + nameof(ProtectedNestedClass);

            public const string InternalNestedClass = PublicParentClass + "+" + nameof(InternalNestedClass);
        }
    }
}
