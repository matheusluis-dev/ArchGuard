namespace ArchGuard.Library.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal static class DirectoryHelper
    {
        private static readonly Dictionary<string, DirectoryInfo> _cache = new Dictionary<
            string,
            DirectoryInfo
        >(StringComparer.OrdinalIgnoreCase);

        internal static DirectoryInfo GetDirectoryInSolution(string subDirectory)
        {
            if (_cache.TryGetValue(subDirectory, out var cacheDirectoryInfo))
                return cacheDirectoryInfo;

            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            while (directory != null)
            {
                var projectFile = directory
                    .EnumerateFiles($"{subDirectory}.csproj", SearchOption.AllDirectories)
                    .FirstOrDefault();

                if (!(projectFile is null))
                {
                    var dir = new DirectoryInfo(Path.GetDirectoryName(projectFile.FullName));
                    _cache[subDirectory] = dir;

                    return dir;
                }

                directory = directory.Parent;
            }

            throw new DirectoryNotFoundException($"Directory '{subDirectory}' not found");
        }
    }
}
