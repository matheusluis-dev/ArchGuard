namespace ArchGuard.Tests.Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
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

        internal static IEnumerable<MethodInfo> GetExtensionMethods(
            this Type type,
            Assembly assembly
        )
        {
            return assembly
                .GetTypes()
                .Where(t => t.IsSealed && t.IsAbstract && !t.IsGenericType && !t.IsNested)
                .SelectMany(t =>
                    t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                )
                .Where(method => method.IsDefined(typeof(ExtensionAttribute), false))
                .Where(method => method.GetParameters().FirstOrDefault().ParameterType == type);
        }
    }
}
