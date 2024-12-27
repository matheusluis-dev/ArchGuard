namespace ArchGuard.Library.Extensions;

internal static class TypeExtensions
{
    internal static bool IsNonRecordClass([NotNull] this Type type)
    {
        return type.IsClass
            && !RecordsHelper.Records.Contains(type.FullName, StringComparer.Ordinal);
    }

    internal static bool IsNotNonRecordClass([NotNull] this Type type)
    {
        return !type.IsNonRecordClass();
    }

    internal static bool IsPrivate([NotNull] this Type type)
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

    internal static bool IsNotPrivate([NotNull] this Type type)
    {
        return !type.IsPrivate();
    }

    /// <summary>
    /// https://stackoverflow.com/questions/4971213/how-to-use-reflection-to-determine-if-a-class-is-internal
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    internal static bool IsInternal([NotNull] this Type type)
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
            && !type.IsNestedFamANDAssem;
    }

    internal static bool IsNotInternal([NotNull] this Type type)
    {
        return !type.IsInternal();
    }

    /// <summary>
    /// https://stackoverflow.com/questions/1827425/how-to-check-programmatically-if-a-type-is-a-struct-or-a-class
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    internal static bool IsStruct([NotNull] this Type type)
    {
        return type.IsValueType && !type.IsEnum;
    }

    internal static bool IsNotStruct([NotNull] this Type type)
    {
        return !type.IsStruct();
    }

    internal static bool IsPartial([NotNull] this Type type)
    {
        return PartialHelper.Types.Contains(type.FullName, StringComparer.Ordinal);
    }

    internal static bool IsNotPartial([NotNull] this Type type)
    {
        return !type.IsPartial();
    }

    internal static bool IsRecord([NotNull] this Type type)
    {
        return RecordsHelper.Records.Contains(type.FullName, StringComparer.Ordinal);
    }

    internal static bool IsNotRecord([NotNull] this Type type)
    {
        return !type.IsRecord();
    }

    internal static bool IsSealed([NotNull] this Type type)
    {
        return type.IsSealed && !type.IsAbstract;
    }

    internal static bool IsNotSealed([NotNull] this Type type)
    {
        return !type.IsSealed();
    }

    internal static bool IsAbstract([NotNull] this Type type)
    {
        return !type.IsSealed && type.IsAbstract;
    }

    internal static bool IsNotAbstract([NotNull] this Type type)
    {
        return !type.IsAbstract();
    }

    internal static bool IsStatic([NotNull] this Type type)
    {
        return type.IsSealed && type.IsAbstract;
    }

    internal static bool IsNotStatic([NotNull] this Type type)
    {
        return !type.IsStatic();
    }
}
