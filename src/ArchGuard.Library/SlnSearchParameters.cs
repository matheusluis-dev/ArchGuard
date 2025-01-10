namespace ArchGuard.Library
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public struct SlnSearchParameters
    {
        public required string SlnPath { get; set; }
        public required string ProjectName { get; set; }
        public string Preprocessor { get; set; }

        public override readonly bool Equals([NotNullWhen(true)] object obj)
        {
            if (obj is not SlnSearchParameters other)
                return false;

            return SlnPath.Equals(other.SlnPath, StringComparison.OrdinalIgnoreCase)
                && ProjectName.Equals(other.ProjectName, StringComparison.OrdinalIgnoreCase)
                && Preprocessor.Equals(other.Preprocessor, StringComparison.OrdinalIgnoreCase);
        }

        public override readonly int GetHashCode()
        {
            return new
            {
                SlnPath,
                ProjectName,
                Preprocessor,
            }.GetHashCode();
        }
    }
}
