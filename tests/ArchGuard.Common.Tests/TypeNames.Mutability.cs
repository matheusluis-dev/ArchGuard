namespace ArchGuard.Tests.Common.Types
{
    public static partial class TypeNames
    {
        public static class Mutability
        {
            public const string PublicMutableClass = Namespaces.Mutability + "." + nameof(PublicMutableClass);

            public const string PublicImmutableClass = Namespaces.Mutability + "." + nameof(PublicImmutableClass);

            public const string PublicImmutableWithInitPropertyClass =
                Namespaces.Mutability + "." + nameof(PublicImmutableWithInitPropertyClass);

            public const string PublicImmutableWithReadOnlyFieldClass =
                Namespaces.Mutability + "." + nameof(PublicImmutableWithReadOnlyFieldClass);

            public const string PublicImmutableWithConstFieldClass =
                Namespaces.Mutability + "." + nameof(PublicImmutableWithConstFieldClass);

            public const string PublicImmutableRecord = Namespaces.Mutability + "." + nameof(PublicImmutableRecord);

            public const string PublicMutableRecord = Namespaces.Mutability + "." + nameof(PublicMutableRecord);

            public const string PublicMutableParentClass =
                Namespaces.Mutability + "." + nameof(PublicMutableParentClass);

            public const string PublicMutableByInheritanceClass =
                Namespaces.Mutability + "." + nameof(PublicMutableByInheritanceClass);

            public const string PublicImmutableWithInheritanceClass =
                Namespaces.Mutability + "." + nameof(PublicImmutableWithInheritanceClass);

            public const string PublicImmutableParentClass =
                Namespaces.Mutability + "." + nameof(PublicImmutableParentClass);
        }
    }
}
