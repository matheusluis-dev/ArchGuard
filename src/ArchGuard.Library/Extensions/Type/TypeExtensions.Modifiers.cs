namespace ArchGuard.Library.Extensions.Type
{
    using System;
    using System.Linq;
    using ArchGuard.Library.Helpers;

    internal static partial class TypeExtensions
    {
        internal static bool IsNonRecordClass(this Type type, StringComparison comparison)
        {
            return type.IsClass
                && !RecordsHelper.Records.Contains(type.FullName, comparison.ToComparer());
        }

        internal static bool IsNotNonRecordClass(this Type type, StringComparison comparison)
        {
            return !type.IsNonRecordClass(comparison);
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

        internal static bool IsPartial(this Type type, StringComparison comparison)
        {
            return PartialHelper.Types.Contains(type.FullName, comparison.ToComparer());
        }

        internal static bool IsNotPartial(this Type type, StringComparison comparison)
        {
            return !type.IsPartial(comparison);
        }

#if NET5_0_OR_GREATER
        internal static bool IsRecord(this Type type, StringComparison comparison)
        {
            return RecordsHelper.Records.Contains(type.FullName, comparison.ToComparer());
        }

        internal static bool IsNotRecord(this Type type, StringComparison comparison)
        {
            return !type.IsRecord(comparison);
        }
#endif

        internal static bool IsSealed(this Type type)
        {
            return type.IsSealed && !type.IsStatic();
        }

        internal static bool IsNotSealed(this Type type)
        {
            return !type.IsSealed();
        }

        internal static bool IsAbstract(this Type type)
        {
            return type.IsAbstract && !type.IsStatic();
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
    }
}
