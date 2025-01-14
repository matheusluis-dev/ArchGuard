namespace ArchGuard.Tests.Common.Types
{
    public static partial class TypeNames
    {
        public static class ExternalMutability
        {
            public const string PublicExternalImmutableWithPrivateFieldNonReadonlyClass =
                Namespaces.ExternalMutability
                + "."
                + nameof(PublicExternalImmutableWithPrivateFieldNonReadonlyClass);

            public const string PublicExternalImmutableEmptyClass =
                Namespaces.ExternalMutability + "." + nameof(PublicExternalImmutableEmptyClass);

            public const string PublicExternalImmutableWithReadonlyFieldClass =
                Namespaces.ExternalMutability
                + "."
                + nameof(PublicExternalImmutableWithReadonlyFieldClass);

            public const string PublicExternalImmutableWithGetOnlyPropertyClass =
                Namespaces.ExternalMutability
                + "."
                + nameof(PublicExternalImmutableWithGetOnlyPropertyClass);

            public const string PublicExternalImmutableWithInitPropertyClass =
                Namespaces.ExternalMutability
                + "."
                + nameof(PublicExternalImmutableWithInitPropertyClass);

            public const string PublicExternalImmutableWithPublicPropertyPrivateSetClass =
                Namespaces.ExternalMutability
                + "."
                + nameof(PublicExternalImmutableWithPublicPropertyPrivateSetClass);

            public const string PublicExternalMutableWithMethodUpdatingPrivateFieldClass =
                Namespaces.ExternalMutability
                + "."
                + nameof(PublicExternalMutableWithMethodUpdatingPrivateFieldClass);
        }
    }
}
