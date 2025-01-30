namespace ArchGuard
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

        internal static Error Sln01SolutionNotFound => new("SLN01", "Solution not found");
        internal static Error Prj01ProjectNotFound => new("PRJ01", "Project not found");

        public override string ToString()
        {
            return $"{Code}: {Description}";
        }
    }
}
