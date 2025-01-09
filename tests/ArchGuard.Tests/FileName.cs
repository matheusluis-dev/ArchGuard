#if NET8_0_OR_GREATER
namespace ArchGuard.Filters.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ArchGuard.Roslyn;
    using Xunit;

    public sealed class FileName
    {
        [Fact]
        public void Compile()
        {
            CompileSolution.Compile(
                "C:\\Users\\matheus.oliveira\\source\\repos\\ArchGuard\\ArchGuard.sln",
                "net9_0"
            );
            CompileSolution.ReadAllDocuments(
                "C:\\Users\\matheus.oliveira\\source\\repos\\ArchGuard\\ArchGuard.sln"
            );
        }
    }
}
#endif
