namespace ArchGuard.Tests.Common
{
    using System.Reflection;
    using ArchGuard.Library.Types.Filters.Common.Interfaces;
    using ArchGuard.Tests.MockedAssembly.Classes.Public;

    internal static class TypesFromMockedAssembly
    {
        private static readonly Assembly _assembly = typeof(PublicClass).Assembly;

        public static ITypesFilterStart All => Library.Types.Types.FromAssembly(_assembly);
    }
}
