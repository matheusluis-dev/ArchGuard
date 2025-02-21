namespace ArchGuard.Tests.Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public static class TypeSpecExtensions
    {
        public static IEnumerable<MethodInfo> GetExtensionMethods(this Type type, Assembly assembly)
        {
            return assembly
                .GetTypes()
                .Where(t => t.IsSealed && t.IsAbstract && !t.IsGenericType && !t.IsNested)
                .SelectMany(t => t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
                .Where(method => method.IsDefined(typeof(ExtensionAttribute), false))
                .Where(method => method.GetParameters().FirstOrDefault().ParameterType == type);
        }
    }
}
