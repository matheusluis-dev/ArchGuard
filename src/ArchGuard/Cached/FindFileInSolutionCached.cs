namespace ArchGuard.Cached
{
    using System.Collections.Generic;
    using System.IO;

    internal static class FindFileHelper
    {
        private static readonly Dictionary<string, FileInfo> _cache = [];

        public static FileInfo GetFileInSolution(string fileSubPath)
        {
            if (_cache.TryGetValue(fileSubPath, out var cacheDirectoryInfo))
                return cacheDirectoryInfo;

            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            while (directory is not null)
            {
                var fileInfo = new FileInfo(Path.Combine(directory.FullName, fileSubPath));

                if (fileInfo.Exists)
                {
                    _cache.Add(fileSubPath, fileInfo);
                    return fileInfo;
                }

                directory = directory.Parent;
            }

            throw new DirectoryNotFoundException($"File '{fileSubPath}' not found");
        }
    }
}
