namespace ArchGuard.Library.Helpers
{
    using System.Collections.Generic;
    using System.IO;

    internal static class DirectoryHelper
    {
        private static readonly Dictionary<string, DirectoryInfo> _cache =
            new Dictionary<string, DirectoryInfo>();

        internal static DirectoryInfo GetDirectoryInSolution(string subDirectory)
        {
            if (_cache.TryGetValue(subDirectory, out var cacheDirectoryInfo))
                return cacheDirectoryInfo;

            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            while (!(directory is null))
            {
                var directoryInfo = new DirectoryInfo(
                    Path.Combine(directory.FullName, subDirectory)
                );
                if (directoryInfo.Exists)
                {
                    _cache.Add(subDirectory, directoryInfo);
                    return directoryInfo;
                }

                directory = directory.Parent;
            }

            throw new DirectoryNotFoundException($"Directory '{subDirectory}' not found");
        }
    }
}
