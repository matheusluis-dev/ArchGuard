namespace ArchGuard.Core.Predicates.Method
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using ArchGuard.Core.Method.Models;

    public static partial class MethodPredicate
    {
        public static Func<MethodDefinition, StringComparison, bool> HaveNamePascalCased =>
            (method, _) => Regex.IsMatch(method._method.Name, RegularExpressions.PascalCase);

        public static Func<MethodDefinition, StringComparison, bool> HaveNameEndingWith(
            IEnumerable<string> names
        )
        {
            return (method, comparison) =>
                names.Any(name => method._method.Name.EndsWith(name, comparison));
        }

        public static Func<MethodDefinition, StringComparison, bool> NotHaveNameEndingWith(
            IEnumerable<string> names
        )
        {
            return (method, comparison) =>
                !names.Any(name => method._method.Name.EndsWith(name, comparison));
        }
    }
}
