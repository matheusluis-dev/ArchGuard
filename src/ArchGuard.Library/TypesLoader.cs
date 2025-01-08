namespace ArchGuard.Library
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

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

        internal static IEnumerable<TypeSpec> LoadFromAssembly(Assembly assembly)
        {
            var assemblySpecification = new AssemblySpec(assembly);

            return assembly
                .GetTypes()
                .Select(type => new TypeSpec(assemblySpecification, type))
                .Where(type =>
                    !_exclusionList.Any(e => type.FullName.StartsWith(e, StringComparison.Ordinal))
                );
        }
    }
}
