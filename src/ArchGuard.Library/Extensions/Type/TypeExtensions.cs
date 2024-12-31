namespace ArchGuard.Library.Extensions.Type
{
    using System;
    using System.Text.RegularExpressions;

    internal static partial class TypeExtensions
    {
        // TODO fix this on all runtimes
        private static readonly Regex _fullNameCleanRegex = new Regex(@"<[^>]+>[^_]+__(.+)$");

        internal static string GetFullNameClean(this Type type)
        {
            var regex = _fullNameCleanRegex;
            var match = regex.Match(type.FullName);

            var @namespace = string.IsNullOrWhiteSpace(type.Namespace)
                ? string.Empty
                : $"{type.Namespace}.";

            return match.Success ? $"{@namespace}{match.Groups[1].Value}" : type.FullName;
        }
    }
}
