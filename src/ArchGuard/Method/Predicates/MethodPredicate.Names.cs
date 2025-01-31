namespace ArchGuard
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using ArchGuard.Kernel;

    internal static partial class MethodPredicate
    {
        public static Func<MethodDefinition, StringComparison, bool> HaveNamePascalCased =>
            (method, _) => Regex.IsMatch(method.Symbol.Name, RegularExpressions.PascalCase);

        public static Func<MethodDefinition, StringComparison, bool> HaveNameEndingWith(
            IEnumerable<string> names
        )
        {
            return (method, comparison) =>
                names.Any(name => method.Symbol.Name.EndsWith(name, comparison));
        }

        public static Func<MethodDefinition, StringComparison, bool> NotHaveNameEndingWith(
            IEnumerable<string> names
        )
        {
            return (method, comparison) =>
                !names.Any(name => method.Symbol.Name.EndsWith(name, comparison));
        }
    }
}
