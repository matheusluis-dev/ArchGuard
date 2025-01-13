namespace ArchGuard.Tests.Common.Types
{
    public static partial class TypeNames
    {
        public static class ImplementInterface
        {
            public const string IPublicInterface =
                Namespaces.ImplementInterface + "." + nameof(IPublicInterface);

            public const string IPublicInheritIPublicInterfaceInterface =
                Namespaces.ImplementInterface
                + "."
                + nameof(IPublicInheritIPublicInterfaceInterface);

            public const string PublicImplementIPublicInterfaceClass =
                Namespaces.ImplementInterface + "." + nameof(PublicImplementIPublicInterfaceClass);

            public const string PublicImplementPublicInterfaceByInheritanceClass =
                Namespaces.ImplementInterface
                + "."
                + nameof(PublicImplementPublicInterfaceByInheritanceClass);

            public const string PublicParentImplementPublicInterfaceByInheritanceClass =
                Namespaces.ImplementInterface
                + "."
                + nameof(PublicParentImplementPublicInterfaceByInheritanceClass);
        }
    }
}
