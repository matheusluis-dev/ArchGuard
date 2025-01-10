namespace ArchGuard.Filters.Tests
{
    using System;
    using ArchGuard.Library;
    using ArchGuard.Library;
    using Xunit;

    public sealed class FileName
    {
        [Fact]
        public void Compile()
        {
            var parameters = new SlnSearchParameters
            {
                SlnPath = "C:\\Users\\matheus.oliveira\\source\\repos\\ArchGuard\\ArchGuard.sln",
                Preprocessor = "net9_0",
                ProjectName = "ArchGuard.Tests.MockedAssembly",
            };
            var t = SolutionReader.CompileSolution(parameters);

            Console.WriteLine();
        }

        [Fact]
        public void Compile2()
        {
            var parameters = new SlnSearchParameters
            {
                SlnPath = "C:\\Users\\matheus.oliveira\\source\\repos\\ArchGuard\\ArchGuard.sln",
                Preprocessor = "net9_0",
                ProjectName = "ArchGuard.Filters.Tests",
            };
            var t = SolutionReader.CompileSolution(parameters);

            Console.WriteLine();
        }
    }
}
