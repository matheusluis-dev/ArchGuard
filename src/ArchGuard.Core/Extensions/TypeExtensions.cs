namespace ArchGuard.Extensions
{
    using System.Text.RegularExpressions;

    public static partial class TypeExtensions
    {
        [GeneratedRegex("<[^>]+>[^_]+__(.+)$", RegexOptions.Compiled, 1000)]
        private static partial Regex RemoveFileLocalRegex();

        public static string GetFullNameClean(this Type type)
        {
            ArgumentNullException.ThrowIfNull(type);

            var match = RemoveFileLocalRegex().Match(type.Name);
            var @namespace = type.Namespace is not null ? $"{type.Namespace}." : string.Empty;

            return match.Success ? @namespace + match.Groups[1].Value : @namespace + type.Name;
        }
    }
}
