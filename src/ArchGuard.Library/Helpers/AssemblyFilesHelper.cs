namespace ArchGuard.Library.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using ArchGuard.Library.Extensions.Type;

    internal static class AssemblyFilesHelper
    {
        private static readonly Dictionary<AssemblySpec, IEnumerable<FileInfo>> _cache =
            new Dictionary<AssemblySpec, IEnumerable<FileInfo>>();

        private static readonly IReadOnlyList<string> _excludedDirectories = new List<string>
        {
            "bin".BetweenDirectorySeparator(),
            "dir".BetweenDirectorySeparator(),
        };

        internal static IEnumerable<FileInfo> GetFiles(AssemblySpec assemblySpecification)
        {
            if (_cache.TryGetValue(assemblySpecification, out var files))
                return files;

            return assemblySpecification
                .Location.EnumerateFiles("*.cs", SearchOption.AllDirectories)
                .Where(file =>
                    _excludedDirectories.Any(dir =>
                        file.FullName.IndexOf(dir, StringComparison.OrdinalIgnoreCase) == -1
                    )
                );
        }
    }
}
