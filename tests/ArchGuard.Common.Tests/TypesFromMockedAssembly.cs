namespace ArchGuard.Tests.Common
{
    using System.Reflection;
    using ArchGuard.Library.Type.Filters;
    using ArchGuard.Tests.MockedAssembly.Classes.Public;

    public static class TypesFromMockedAssembly
    {
        private static readonly Assembly _assembly = typeof(PublicClass).Assembly;

        public static ITypesFilterStart All => Library.Type.Types.FromAssembly(_assembly);
    }
}
