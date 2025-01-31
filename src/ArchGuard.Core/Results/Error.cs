namespace ArchGuard.Core.Results
{
    public record Error
    {
        private Error() { }

        private Error(string code, string description)
        {
            Code = code;
            Description = description;
        }

        internal string Code { get; init; } = string.Empty;
        internal string Description { get; init; } = string.Empty;

        public static Error Sln01SolutionNotFound(string solutionPath)
        {
            return new("SLN01", $"Solution `{solutionPath}` not found");
        }

        public static Error Prj01ProjectNotFound(string projectName)
        {
            return new("PRJ01", $"Project `{projectName}` not found");
        }

        public override string ToString()
        {
            return $"{Code}: {Description}";
        }
    }
}
