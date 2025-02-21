namespace ArchGuard.Tests.Common.Types
{
    public static partial class TypeNames
    {
        public static class Generics
        {
            public const string IPublicGenericOneTypeInterface =
                Namespaces.Generics + "." + nameof(IPublicGenericOneTypeInterface);

            public const string IPublicGenericTwoTypesInterface =
                Namespaces.Generics + "." + nameof(IPublicGenericTwoTypesInterface);

            public const string PublicGenericOneTypeClass =
                Namespaces.Generics + "." + nameof(PublicGenericOneTypeClass);

            public const string PublicGenericTwoTypesClass =
                Namespaces.Generics + "." + nameof(PublicGenericTwoTypesClass);

            public const string IPublicNonGenericInterface =
                Namespaces.Generics + "." + nameof(IPublicNonGenericInterface);

            public const string PublicNonGenericClass = Namespaces.Generics + "." + nameof(PublicNonGenericClass);

            public const string PublicNonGenericInheritGenericClass =
                Namespaces.Generics + "." + nameof(PublicNonGenericInheritGenericClass);

            public const string PublicParentNonGenericInheritGenericClass =
                Namespaces.Generics + "." + nameof(PublicParentNonGenericInheritGenericClass);

            public const string PublicGenericInheritGenericClass =
                Namespaces.Generics + "." + nameof(PublicGenericInheritGenericClass);

            public const string PublicParentGenericInheritGenericClass =
                Namespaces.Generics + "." + nameof(PublicParentGenericInheritGenericClass);

            public const string PublicGenericOneTypeArgumentInheritTwoTypesArgumentClass =
                Namespaces.Generics + "." + nameof(PublicGenericOneTypeArgumentInheritTwoTypesArgumentClass);

            public const string PublicParentGenericOneTypeArgumentInheritTwoTypesArgumentClass =
                Namespaces.Generics + "." + nameof(PublicParentGenericOneTypeArgumentInheritTwoTypesArgumentClass);
        }
    }
}
