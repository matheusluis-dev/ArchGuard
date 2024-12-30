namespace ArchGuard.Library.Extensions
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using ArchGuard.Library.Helpers;

    internal static class TypeExtensions
    {
        internal static string CleanFullName(this Type type)
        {
            var regex = new Regex(@"<[^>]+>[^_]+__(.+)$");
            var match = regex.Match(type.FullName);

            return match.Success ? type.Namespace + "." + match.Groups[1].Value : type.FullName;
        }

        internal static bool IsNonRecordClass(this Type type)
        {
            return type.IsClass
                && !RecordsHelper.Records.Contains(type.FullName, StringComparer.Ordinal);
        }

        internal static bool IsNotNonRecordClass(this Type type)
        {
            return !type.IsNonRecordClass();
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

        /// <summary>
        /// https://stackoverflow.com/questions/4971213/how-to-use-reflection-to-determine-if-a-class-is-internal
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static bool IsInternal(this Type type)
        {
            return type.IsNotPublic
                && !type.IsVisible
                && !type.IsPublic
                && !type.IsNested
                && !type.IsNestedPublic
                && !type.IsNestedFamily
                && !type.IsNestedPrivate
                && !type.IsNestedAssembly
                && !type.IsNestedFamORAssem
                && !type.IsNestedFamANDAssem
#if NET7_0_OR_GREATER
                && !type.IsFileScoped()
#endif
            ;
        }

        internal static bool IsNotInternal(this Type type)
        {
            return !type.IsInternal();
        }

        /// <summary>
        /// https://stackoverflow.com/questions/1827425/how-to-check-programmatically-if-a-type-is-a-struct-or-a-class
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static bool IsStruct(this Type type)
        {
            return type.IsValueType && !type.IsEnum;
        }

        internal static bool IsNotStruct(this Type type)
        {
            return !type.IsStruct();
        }

        internal static bool IsPartial(this Type type)
        {
            return PartialHelper.Types.Contains(type.FullName, StringComparer.Ordinal);
        }

        internal static bool IsNotPartial(this Type type)
        {
            return !type.IsPartial();
        }

        internal static bool IsRecord(this Type type)
        {
            return RecordsHelper.Records.Contains(type.FullName, StringComparer.Ordinal);
        }

        internal static bool IsNotRecord(this Type type)
        {
            return !type.IsRecord();
        }

        internal static bool IsSealed(this Type type)
        {
            return type.IsSealed && !type.IsAbstract;
        }

        internal static bool IsNotSealed(this Type type)
        {
            return !type.IsSealed();
        }

        internal static bool IsAbstract(this Type type)
        {
            return !type.IsSealed && type.IsAbstract;
        }

        internal static bool IsNotAbstract(this Type type)
        {
            return !type.IsAbstract();
        }

        internal static bool IsStatic(this Type type)
        {
            return type.IsSealed && type.IsAbstract;
        }

        internal static bool IsNotStatic(this Type type)
        {
            return !type.IsStatic();
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

        internal static bool IsFileScoped(this Type type)
        {
            var fullName = type.FullName;
            var cleanFullName = type.CleanFullName();

            return !fullName.Equals(cleanFullName, StringComparison.Ordinal)
                && FileAccessModifierHelper.Types.Contains(cleanFullName, StringComparer.Ordinal);
        }

        internal static bool IsNotFileScoped(this Type type)
        {
            return !type.IsFileScoped();
        }
    }
}
