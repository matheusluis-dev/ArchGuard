namespace ArchGuard.Tests.Common.Extensions
{
    using System;
    using System.Text.RegularExpressions;

    internal static class TypeExtensions
    {
        internal static string FullNameClean(this Type type)
        {
            var fullName = type.FullName;

            var regex = new Regex(@"<[^>]+>[^_]+__(.+)$");
            var match = regex.Match(fullName);

            return match.Success ? type.Namespace + "." + match.Groups[1].Value : fullName;
        }
    }
}
