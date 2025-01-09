namespace ArchGuard.Roslyn
{
    public struct SolutionSearchParameters
    {
        public required string SlnPath { get; set; }
        public string Preprocessor { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is not SolutionSearchParameters other)
                return false;

            return obj.Equals(other);
        }

        public override int GetHashCode()
        {
            return new { SlnPath, Preprocessor }.GetHashCode();
        }

        public static bool operator ==(
            SolutionSearchParameters left,
            SolutionSearchParameters right
        )
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            SolutionSearchParameters left,
            SolutionSearchParameters right
        )
        {
            return !(left == right);
        }
    }
}
