namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using ArchGuard.Library.Extensions;

    internal static partial class TypeSpecPredicate
    {
        internal static Func<TypeSpecRoslyn, StringComparison, bool> HaveName(
            IEnumerable<string> name
        )
        {
            return (type, comparison) => name.Contains(type.Name, comparison.ToComparer());
        }

        internal static Func<TypeSpecRoslyn, StringComparison, bool> HaveNameMatching(
            IEnumerable<string> regexes
        )
        {
            return (type, _) => regexes.Any(regex => Regex.IsMatch(type.Name, regex));
        }

        internal static Func<TypeSpecRoslyn, StringComparison, bool> HaveNameNotMatching(
            IEnumerable<string> regex
        )
        {
            return (type, _) => !HaveNameMatching(regex)(type, _);
        }

        internal static Func<TypeSpecRoslyn, StringComparison, bool> HaveFullName(
            IEnumerable<string> name
        )
        {
            return (type, comparison) => name.Contains(type.FullName, comparison.ToComparer());
        }

        internal static Func<TypeSpecRoslyn, StringComparison, bool> HaveFullNameMatching(
            IEnumerable<string> regexes
        )
        {
            return (type, _) => regexes.Any(regex => Regex.IsMatch(type.FullName, regex));
        }

        internal static Func<TypeSpecRoslyn, StringComparison, bool> HaveFullNameNotMatching(
            IEnumerable<string> regexes
        )
        {
            return (type, _) => !HaveFullNameMatching(regexes)(type, _);
        }

        internal static Func<TypeSpecRoslyn, StringComparison, bool> HaveNameStartingWith(
            IEnumerable<string> name
        )
        {
            return (type, comparison) => name.Any(n => type.Name.StartsWith(n, comparison));
        }

        internal static Func<TypeSpecRoslyn, StringComparison, bool> HaveNameEndingWith(
            IEnumerable<string> name
        )
        {
            return (type, comparison) => name.Any(n => type.Name.EndsWith(n, comparison));
        }
    }
}
