namespace ArchGuard.Library.Extensions;

using ArchGuard.Library.Helpers;

public static class TypeExtensions
{
    public static bool IsPrivate(this Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

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

    public static bool IsNotPrivate(this Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        return !type.IsPrivate();
    }

    /// <summary>
    /// https://stackoverflow.com/questions/4971213/how-to-use-reflection-to-determine-if-a-class-is-internal
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static bool IsInternal(this Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

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

    public static bool IsNotInternal(this Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        return !type.IsInternal();
    }

    /// <summary>
    /// https://stackoverflow.com/questions/1827425/how-to-check-programmatically-if-a-type-is-a-struct-or-a-class
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static bool IsStruct(this Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        return type.IsValueType && !type.IsEnum;
    }

    public static bool IsNotStruct(this Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        return !type.IsStruct();
    }

    public static bool IsPartial(this Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        return PartialClassesHelper.Classes.Contains(type.FullName);
    }

    public static bool IsNotPartial(this Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        return !type.IsPartial();
    }
}
