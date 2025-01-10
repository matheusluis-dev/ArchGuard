namespace ArchGuard.Library.Extensions.Type
{
    using System;

    internal static partial class TypeExtensions
    {
        internal static bool IsPublic(this Type type)
        {
            return type.IsPublic || type.IsNestedPublic;
        }

        internal static bool IsNotPublic(this Type type)
        {
            return type.IsNotPublic && !type.IsNestedPublic;
        }

        internal static bool IsPrivate(this Type type)
        {
            return type.IsNested
                && type.IsNestedPrivate
                && !type.IsVisible
                && !type.IsPublic
                && !type.IsNotPublic
                && !type.IsNestedPublic
                && !type.IsNestedFamily
                && !type.IsNestedAssembly
                && !type.IsNestedFamORAssem
                && !type.IsNestedFamANDAssem;
        }

        internal static bool IsNotPrivate(this Type type)
        {
            return !type.IsPrivate();
        }

        internal static bool IsProtected(this Type type)
        {
            return !type.IsVisible
                && !type.IsPublic
                && !type.IsNotPublic
                && type.IsNested
                && !type.IsNestedPublic
                && type.IsNestedFamily
                && !type.IsNestedPrivate
                && !type.IsNestedAssembly
                && !type.IsNestedFamORAssem
                && !type.IsNestedFamANDAssem;
        }

        internal static bool IsNotProtected(this Type type)
        {
            return !type.IsProtected();
        }
    }
}
