namespace ArchGuard.Library
{
    using System.Collections.Generic;
    using System.Reflection;
    using ArchGuard.Library.Helpers;

    internal static class TypesLoader
    {
        private static readonly string[] _exclusionList = new string[]
        {
            "System",
            "Microsoft",
            "netstandard",
            "NuGet",
            "Newtonsoft",
            "xunit",
            "Internal.Microsoft",
            "Mono.Cecil",
            "ArchGuard.Library",
        };

        internal static IEnumerable<TypeSpecRoslyn> LoadFromAssembly(Assembly assembly)
        {
            var assemblySpecification = new AssemblySpec(assembly);

            return AssemblyFilesHelper.Load(assemblySpecification);
        }
    }
}
