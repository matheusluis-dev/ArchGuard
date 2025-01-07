namespace ArchGuard.Library.Extensions.Type
{
    using System;
#if NET7_0_OR_GREATER
    using System.Linq;
    using ArchGuard.Library.Helpers;
    using ArchGuard.Library.Type;
#endif

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

        internal static bool IsInternal(this Type type, StringComparison comparison)
        {
            // https://stackoverflow.com/questions/4971213/how-to-use-reflection-to-determine-if-a-class-is-internal
            var isInternal = type.IsNotPublic;
#if NET7_0_OR_GREATER
            isInternal = isInternal && !type.IsFileScoped(comparison);
#endif
            isInternal = isInternal || (type.IsNested && type.IsNestedAssembly);

            return isInternal;
        }

        internal static bool IsNotInternal(this Type type, StringComparison comparison)
        {
            return !type.IsInternal(comparison);
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

#if NET7_0_OR_GREATER
        internal static bool IsFileScoped(this Type type, StringComparison comparison)
        {
            var fullName = type.FullName;
            var cleanFullName = type.GetFullNameClean();

            // TODO: test it
            return !fullName.Equals(cleanFullName, comparison)
                && FileAccessModifierHelper.Types.Contains(cleanFullName, StringComparer.Ordinal);
        }

        internal static bool IsNotFileScoped(this Type type, StringComparison comparison)
        {
            return !type.IsFileScoped(comparison);
        }
#endif
    }
}
