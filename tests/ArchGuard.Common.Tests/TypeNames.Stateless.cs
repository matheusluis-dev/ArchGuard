namespace ArchGuard.Tests.Common.Types
{
    public static partial class TypeNames
    {
        public static class Stateless
        {
            public const string PublicNonStatelessClass =
                Namespaces.Stateless + "." + nameof(PublicNonStatelessClass);

            public const string PublicStatelessClass =
                Namespaces.Stateless + "." + nameof(PublicStatelessClass);
        }
    }
}
