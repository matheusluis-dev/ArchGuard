namespace ArchGuard.Tests.Common
{
    using ArchGuard.Library;
    using ArchGuard.Library.Type.Filters;

    public static class TypesFromMockedAssembly
    {
        public static ITypesFilterStart All =>
            Library.Type.Types.FromSln(
                new SlnSearchParameters
                {
                    SlnPath = "C:\\Users\\mathe\\source\\github\\me\\ArchGuard\\ArchGuard.sln",
                    Preprocessor = "net9_0",
                    ProjectName = "ArchGuard.Tests.MockedAssembly",
                }
            );
    }
}
