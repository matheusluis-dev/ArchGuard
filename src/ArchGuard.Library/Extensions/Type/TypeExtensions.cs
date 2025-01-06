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

        private static string CleanFileScopedName(string name, string @namespace = "")
        {
            var regex = FileScopedRegex();
            var match = regex.Match(name);

            return match.Success ? @namespace + match.Groups[1].Value : name;
        }

        private static string CleanGenericTypeName(string name)
        {
            var index = name.Length - 2;

            if (name[index] == '`')
                return name.Substring(0, index);

            return name;
        }

        internal static string GetNameClean(this Type type)
        {
            var name = type.Name;
            name = CleanFileScopedName(name);
            name = CleanGenericTypeName(name);

            return name;
        }

        internal static string GetFullNameClean(this Type type)
        {
            var @namespace = string.IsNullOrWhiteSpace(type.Namespace)
                ? string.Empty
                : $"{type.Namespace}.";

            var fullName = type.FullName;
            fullName = CleanFileScopedName(fullName, @namespace);
            fullName = CleanGenericTypeName(fullName);

            return fullName;
        }
    }
}
