namespace ArchGuard.Library.Helpers;

internal static class RecordsHelper
{
    private static readonly Lazy<IEnumerable<string>> _cache = new(Load);

    internal static IEnumerable<string> Records => _cache.Value;

    private static IEnumerable<string> Load()
    {
        return ApplicationCSharpFilesHelper.Files.SelectMany(file =>
        {
            var code = File.ReadAllText(file.FullName);
            var syntaxTree = CSharpSyntaxTree.ParseText(code);
            var root = syntaxTree.GetRoot();

            return root.DescendantNodes()
                .OfType<RecordDeclarationSyntax>()
                .Select(c => c.GetFullName());
        });
    }
}
