namespace ArchGuard.Tests.Common.Types
{
    public static partial class TypeNames
    {
        public static class ImplementInterface
        {
            public const string IPublicInterface1 =
                Namespaces.ImplementInterface + "." + nameof(IPublicInterface1);

            public const string IPublicInheritIPublicInterface1Interface =
                Namespaces.ImplementInterface
                + "."
                + nameof(IPublicInheritIPublicInterface1Interface);

            public const string PublicImplementIPublicInterface1Class =
                Namespaces.ImplementInterface + "." + nameof(PublicImplementIPublicInterface1Class);

            public const string PublicImplementPublicInterface1ByInheritanceClass =
                Namespaces.ImplementInterface
                + "."
                + nameof(PublicImplementPublicInterface1ByInheritanceClass);

            public const string PublicParentImplementPublicInterface1ByInheritanceClass =
                Namespaces.ImplementInterface
                + "."
                + nameof(PublicParentImplementPublicInterface1ByInheritanceClass);

            public const string IPublicInterface2 =
                Namespaces.ImplementInterface + "." + nameof(IPublicInterface2);

            public const string PublicImplementPublicInterface2Class =
                Namespaces.ImplementInterface + "." + nameof(PublicImplementPublicInterface2Class);
        }
    }
}
