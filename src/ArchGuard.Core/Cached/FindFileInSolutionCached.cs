namespace ArchGuard.Cached
{
    using System.Collections.Generic;
    using System.IO;
    using ArchGuard.Core.Results;

    public static class FindFileHelper
    {
        private static readonly Dictionary<string, FileInfo> _cache = [];

        public static Result<FileInfo> GetFileInSolution(string fileSubPath)
        {
            if (_cache.TryGetValue(fileSubPath, out var cacheDirectoryInfo))
                return Result<FileInfo>.Success(cacheDirectoryInfo);

            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            while (directory is not null)
            {
                var fileInfo = new FileInfo(Path.Combine(directory.FullName, fileSubPath));

                if (fileInfo.Exists)
                {
                    _cache.Add(fileSubPath, fileInfo);

                    return Result<FileInfo>.Success(fileInfo);
                }

                directory = directory.Parent;
            }

            return Result<FileInfo>.Failure(Error.Prj01ProjectNotFound(fileSubPath));
        }
    }
}
