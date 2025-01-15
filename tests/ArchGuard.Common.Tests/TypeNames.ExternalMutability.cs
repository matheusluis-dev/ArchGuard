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

            public const string PublicExternalMutableWithMethodUpdatingPrivatePropertyClass =
                Namespaces.ExternalMutability
                + "."
                + nameof(PublicExternalMutableWithMethodUpdatingPrivatePropertyClass);

            public const string PublicExternalMutableWithMethodUpdatingPublicPropertyPrivateSetClass =
                Namespaces.ExternalMutability
                + "."
                + nameof(PublicExternalMutableWithMethodUpdatingPublicPropertyPrivateSetClass);

            public const string PublicExternalMutableWithGetMethodUpdatingPrivateFieldClass =
                Namespaces.ExternalMutability
                + "."
                + nameof(PublicExternalMutableWithGetMethodUpdatingPrivateFieldClass);

            public const string PublicExternalMutableWithSetMethodUpdatingPrivateFieldClass =
                Namespaces.ExternalMutability
                + "."
                + nameof(PublicExternalMutableWithSetMethodUpdatingPrivateFieldClass);

            public const string PublicExternalMutableWithMethodCallingMethodUpdatePublicPropertyPrivateSetClass =
                Namespaces.ExternalMutability
                + "."
                + nameof(
                    PublicExternalMutableWithMethodCallingMethodUpdatePublicPropertyPrivateSetClass
                );

            public const string PublicExternalMutableWithMethodCallingGetWithUpdatePublicPropertyPrivateSetClass =
                Namespaces.ExternalMutability
                + "."
                + nameof(
                    PublicExternalMutableWithMethodCallingGetWithUpdatePublicPropertyPrivateSetClass
                );

            public const string PublicExternalMutableWithMethodCallingSetWithUpdatePublicPropertyClass =
                Namespaces.ExternalMutability
                + "."
                + nameof(PublicExternalMutableWithMethodCallingSetWithUpdatePublicPropertyClass);

            public const string PublicExternalMutableWithSetMethodUpdatingPrivatePropertyClass =
                Namespaces.ExternalMutability
                + "."
                + nameof(PublicExternalMutableWithSetMethodUpdatingPrivatePropertyClass);
        }
    }
}
