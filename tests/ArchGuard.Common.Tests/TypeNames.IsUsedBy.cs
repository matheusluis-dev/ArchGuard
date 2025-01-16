namespace ArchGuard.Tests.Common.Types
{
    public static partial class TypeNames
    {
        public static class IsUsedBy
        {
            public const string PublicClass = Namespaces.IsUsedBy + "." + nameof(PublicClass);

            public const string PublicDependsOnPropertyClass =
                Namespaces.IsUsedBy + "." + nameof(PublicDependsOnPropertyClass);
        }
    }
}
