namespace ArchGuard.Tests.Common.Types
{
    public static partial class TypeNames
    {
        public static class Inherit
        {
            public const string IPublicInterface =
                Namespaces.Inherit + "." + nameof(IPublicInterface);

            public const string IPublicInheritIPublicInterfaceInterface =
                Namespaces.Inherit + "." + nameof(IPublicInheritIPublicInterfaceInterface);

            public const string IPublicInheritIPublicInterfaceByInheritanceInterface =
                Namespaces.Inherit
                + "."
                + nameof(IPublicInheritIPublicInterfaceByInheritanceInterface);

            public const string IPublicParentInheritIPublicInterfaceByInheritanceInterface =
                Namespaces.Inherit
                + "."
                + nameof(IPublicParentInheritIPublicInterfaceByInheritanceInterface);

            public const string PublicClass = Namespaces.Inherit + "." + nameof(PublicClass);

            public const string PublicInheritPublicClassClass =
                Namespaces.Inherit + "." + nameof(PublicInheritPublicClassClass);

            public const string PublicInheritPublicClassByInheritanceClass =
                Namespaces.Inherit + "." + nameof(PublicInheritPublicClassByInheritanceClass);

            public const string PublicParentInheritPublicClassByInheritanceClass =
                Namespaces.Inherit + "." + nameof(PublicParentInheritPublicClassByInheritanceClass);

            public const string PublicImplementIPublicInterfaceClass =
                Namespaces.Inherit + "." + nameof(PublicImplementIPublicInterfaceClass);
        }
    }
}
