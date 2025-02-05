namespace ArchGuard.Core
{
    public static class RegularExpressions
    {
        public static string PascalCase => "^[A-Z][a-zA-Z0-9]*$";

        public static string CamelCase(string prefix)
        {
            return $"^{prefix}[a-z][a-zA-Z0-9]*$";
        }
    }
}
