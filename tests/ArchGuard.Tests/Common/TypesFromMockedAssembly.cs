namespace ArchGuard.Tests.Common;

using ArchGuard.Library.Types.Filters.Common.Interfaces;

internal static class TypesFromMockedAssembly
{
    private static readonly Assembly _assembly = typeof(PublicClass).Assembly;

    public static ITypesFilterStart All => Types.FromAssembly(_assembly);
}
