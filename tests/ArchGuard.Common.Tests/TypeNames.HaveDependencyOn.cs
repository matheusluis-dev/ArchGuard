namespace ArchGuard.Tests.Common.Types
{
    public static partial class TypeNames
    {
        public static class HaveDependencyOn
        {
            public const string PublicClass =
                Namespaces.HaveDependencyOn + "." + nameof(PublicClass);

            public const string PublicDependsOnPropertyClass =
                Namespaces.HaveDependencyOn + "." + nameof(PublicDependsOnPropertyClass);

            public const string PublicDependsOnFieldClass =
                Namespaces.HaveDependencyOn + "." + nameof(PublicDependsOnFieldClass);

            public const string PublicDependsOnMethodReturnClass =
                Namespaces.HaveDependencyOn + "." + nameof(PublicDependsOnMethodReturnClass);

            public const string PublicDependsOnMethodParameterClass =
                Namespaces.HaveDependencyOn + "." + nameof(PublicDependsOnMethodParameterClass);

            public const string PublicDependsOnMethodBodyClass =
                Namespaces.HaveDependencyOn + "." + nameof(PublicDependsOnMethodBodyClass);

            public const string PublicDependsOnMethodBodyStaticCallClass =
                Namespaces.HaveDependencyOn
                + "."
                + nameof(PublicDependsOnMethodBodyStaticCallClass);

            public const string PublicClassExternalStaticConstructor =
                Namespaces.HaveDependencyOn + "." + nameof(PublicClassExternalStaticConstructor);

            public const string PublicDependsOnMethodBodyCallingStaticConstructorClass =
                Namespaces.HaveDependencyOn
                + "."
                + nameof(PublicDependsOnMethodBodyCallingStaticConstructorClass);

            public const string PublicDependsOnDirectlyClass =
                Namespaces.HaveDependencyOn + "." + nameof(PublicDependsOnDirectlyClass);

            public const string PublicDependsOnIndirectlyClass =
                Namespaces.HaveDependencyOn + "." + nameof(PublicDependsOnIndirectlyClass);
        }
    }
}
