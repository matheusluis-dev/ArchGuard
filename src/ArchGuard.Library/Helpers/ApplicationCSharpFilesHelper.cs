namespace ArchGuard.Library.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal static class ApplicationCSharpFilesHelper
    {
        private static readonly Lazy<IEnumerable<FileInfo>> _cache = new Lazy<
            IEnumerable<FileInfo>
        >(LoadFiles);

        internal static IEnumerable<FileInfo> Files => _cache.Value;

        private static IEnumerable<FileInfo> LoadFiles()
        {
            // TODO remove this hardcode
            var directoryInfo = DirectoryHelper.GetDirectoryInSolution(
                "tests/ArchGuard.Tests.MockedAssembly"
            );

            var excludedDirectories = new[] { "bin", "obj" };
            return directoryInfo
                .EnumerateFiles("*.cs", SearchOption.AllDirectories)
                .Where(file =>
                    !excludedDirectories.Any(dir =>
                        file.FullName.IndexOf(
                            $"{Path.DirectorySeparatorChar}{dir}{Path.DirectorySeparatorChar}",
                            StringComparison.OrdinalIgnoreCase
                        ) != -1
                    )
                );
        }
    }
}
