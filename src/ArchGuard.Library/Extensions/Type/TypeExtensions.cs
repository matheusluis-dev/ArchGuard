namespace ArchGuard.Library.Extensions.Type
{
    using System;
    using System.Text.RegularExpressions;

    internal static partial class TypeExtensions
    {
        private static Regex FileScopedRegex()
        {
            return new Regex("<[^>]+>[^_]+__(.+)$", RegexOptions.None, TimeSpan.FromSeconds(1));
        }

        private static string CleanFileScopedName(string @namespace, string fullName)
        {
            var regex = FileScopedRegex();
            var match = regex.Match(fullName);

            return match.Success ? @namespace + match.Groups[1].Value : fullName;
        }

        private static string CleanGenericTypeName(string fullName)
        {
            var index = fullName.Length - 2;

            if (fullName[index] == '`')
                return fullName.Substring(0, index);

            return fullName;
        }

        internal static string GetFullNameClean(this Type type)
        {
            var @namespace = string.IsNullOrWhiteSpace(type.Namespace)
                ? string.Empty
                : $"{type.Namespace}.";

            var fullName = CleanFileScopedName(@namespace, type.FullName);
            fullName = CleanGenericTypeName(fullName);

            return fullName;
        }
    }
}
