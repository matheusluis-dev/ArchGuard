namespace ArchGuard.Extensions
{
    using System.Text.RegularExpressions;

    public static class TypeExtensions
    {
        public static string GetFullNameClean(this System.Type type)
        {
            var match = Regex.Match(type.FullName, @"<[^>]+>[^_]+__(.+)$");

            return match.Success ? type.Namespace + "." + match.Groups[1].Value : type.FullName;
        }
    }
}
