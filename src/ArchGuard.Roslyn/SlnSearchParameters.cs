namespace ArchGuard.Roslyn
{
    public struct SlnSearchParameters
    {
        public required string SlnPath { get; set; }
        public required string ProjectName { get; set; }
        public string Preprocessor { get; set; }
    }
}
