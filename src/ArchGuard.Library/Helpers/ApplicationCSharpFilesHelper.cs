namespace ArchGuard.Library.Helpers;

internal class ApplicationCSharpFilesHelper
{
    private static readonly Lazy<IEnumerable<FileInfo>> _cache = new(LoadFiles);

    internal static IEnumerable<FileInfo> Files => _cache.Value;

    private static IEnumerable<FileInfo> LoadFiles()
    {
        // TODO remove this hardcode
        var directoryInfo = DirectoryHelper.GetDirectoryInSolution(
            "tests/ArchGuard.Tests.MockedAssembly"
        );

        // TODO Find a less stupid way to do this
        return directoryInfo
            .EnumerateFiles("*.cs", SearchOption.AllDirectories)
            .Where(file =>
                !file.FullName.Contains(
                    $"{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}",
                    StringComparison.OrdinalIgnoreCase
                )
                && !file.FullName.Contains(
                    $"{Path.DirectorySeparatorChar}obj{Path.DirectorySeparatorChar}",
                    StringComparison.OrdinalIgnoreCase
                )
            );
    }
}
