namespace ArchGuard.Library.Extensions.Type
{
    using System;
    using System.Text.RegularExpressions;

    internal static partial class TypeExtensions
    {
        private static Regex MyRegex()
        {
            return new Regex("<[^>]+>[^_]+__(.+)$", RegexOptions.None, TimeSpan.FromSeconds(1));
        }

        internal static string GetFullNameClean(this Type type)
        {
            var regex = MyRegex();
            var match = regex.Match(type.FullName);

            var @namespace = string.IsNullOrWhiteSpace(type.Namespace)
                ? string.Empty
                : $"{type.Namespace}.";

            return match.Success ? @namespace + match.Groups[1].Value : type.FullName;
        }
    }
}
