namespace ArchGuard.Tests.Common.Extensions;

internal static class IEnumerableTypeExtensions
{
    internal static IEnumerable<string> GetFullNamesOrdered(this IEnumerable<Type> types)
    {
        return types.Select(type => type.FullName!).Order(StringComparer.Ordinal);
    }
}
