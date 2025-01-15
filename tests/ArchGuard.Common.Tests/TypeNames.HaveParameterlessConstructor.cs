namespace ArchGuard.Tests.Common.Types
{
    public static partial class TypeNames
    {
        public static class HaveParameterlessConstructor
        {
            public const string PublicOneParameterlessConstructorClass =
                Namespaces.HaveParameterlessConstructor
                + "."
                + nameof(PublicOneParameterlessConstructorClass);

            public const string PublicOnlyParameterlessConstructorClass =
                Namespaces.HaveParameterlessConstructor
                + "."
                + nameof(PublicOnlyParameterlessConstructorClass);

            public const string PublicWithoutParameterlessConstructorClass =
                Namespaces.HaveParameterlessConstructor
                + "."
                + nameof(PublicWithoutParameterlessConstructorClass);
        }
    }
}
