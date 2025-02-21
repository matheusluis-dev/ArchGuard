namespace ArchGuard.Tests.Common.Types
{
    public static partial class TypeNames
    {
        public static class Staticless
        {
            public const string PublicNonStaticlessClass =
                Namespaces.Staticless + "." + nameof(PublicNonStaticlessClass);

            public const string PublicStaticlessClass = Namespaces.Staticless + "." + nameof(PublicStaticlessClass);
        }
    }
}
