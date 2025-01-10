namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using ArchGuard.Library.Extensions;
    using Microsoft.CodeAnalysis;

    internal static partial class TypePredicate
    {
        internal static Func<INamedTypeSymbol, StringComparison, bool> HaveName(
            IEnumerable<string> names
        )
        {
            return (type, comparison) => names.Contains(type.GetName(), comparison.ToComparer());
        }

        internal static Func<INamedTypeSymbol, StringComparison, bool> HaveNameMatching(
            IEnumerable<string> regexes
        )
        {
            return (type, _) => regexes.Any(regex => Regex.IsMatch(type.GetName(), regex));
        }

        internal static Func<INamedTypeSymbol, StringComparison, bool> HaveNameNotMatching(
            IEnumerable<string> regex
        )
        {
            return (type, _) => !HaveNameMatching(regex)(type, _);
        }

        internal static Func<INamedTypeSymbol, StringComparison, bool> HaveFullName(
            IEnumerable<string> name
        )
        {
            return (type, comparison) => name.Contains(type.GetFullName(), comparison.ToComparer());
        }

        internal static Func<INamedTypeSymbol, StringComparison, bool> HaveFullNameMatching(
            IEnumerable<string> regexes
        )
        {
            return (type, _) => regexes.Any(regex => Regex.IsMatch(type.GetFullName(), regex));
        }

        internal static Func<INamedTypeSymbol, StringComparison, bool> HaveFullNameNotMatching(
            IEnumerable<string> regexes
        )
        {
            return (type, _) => !HaveFullNameMatching(regexes)(type, _);
        }

        internal static Func<INamedTypeSymbol, StringComparison, bool> HaveNameStartingWith(
            IEnumerable<string> name
        )
        {
            return (type, comparison) => name.Any(n => type.GetName().StartsWith(n, comparison));
        }

        internal static Func<INamedTypeSymbol, StringComparison, bool> HaveNameEndingWith(
            IEnumerable<string> name
        )
        {
            return (type, comparison) => name.Any(n => type.GetName().EndsWith(n, comparison));
        }
    }
}
