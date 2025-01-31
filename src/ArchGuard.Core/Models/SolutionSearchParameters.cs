namespace ArchGuard.Core.Models
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public struct SolutionSearchParameters
    {
        public required string SolutionPath { get; set; }
        public required string ProjectName { get; set; }
        public string Preprocessor { get; set; }

        public override readonly bool Equals([NotNullWhen(true)] object obj)
        {
            if (obj is not SolutionSearchParameters other)
                return false;

            return SolutionPath.Equals(other.SolutionPath, StringComparison.OrdinalIgnoreCase)
                && ProjectName.Equals(other.ProjectName, StringComparison.OrdinalIgnoreCase)
                && Preprocessor.Equals(other.Preprocessor, StringComparison.OrdinalIgnoreCase);
        }

        public override readonly int GetHashCode()
        {
            var slnPath = SolutionPath.ToUpperInvariant();
            var projectName = ProjectName.ToUpperInvariant();
            var preprocessor = Preprocessor.ToUpperInvariant();

            return new
            {
                slnPath,
                projectName,
                preprocessor,
            }.GetHashCode();
        }
    }
}
