namespace ArchGuardType.Predicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using ArchGuard.Extensions;
    using Microsoft.CodeAnalysis;

    internal static partial class TypeDefinitionPredicate
    {
        internal static Func<TypeDefinition, StringComparison, bool> HaveName(
            IEnumerable<string> names
        )
        {
            return (type, comparison) =>
                names.Contains(type.Symbol.GetName(), comparison.ToComparer());
        }

        internal static Func<TypeDefinition, StringComparison, bool> HaveNameMatching(
            IEnumerable<string> regexes
        )
        {
            return (type, _) => regexes.Any(regex => Regex.IsMatch(type.Symbol.GetName(), regex));
        }

        internal static Func<TypeDefinition, StringComparison, bool> HaveNameNotMatching(
            IEnumerable<string> regex
        )
        {
            return (type, _) => !HaveNameMatching(regex)(type, _);
        }

        internal static Func<TypeDefinition, StringComparison, bool> HaveFullName(
            IEnumerable<string> name
        )
        {
            return (type, comparison) =>
                name.Contains(type.Symbol.GetFullName(), comparison.ToComparer());
        }

        internal static Func<TypeDefinition, StringComparison, bool> HaveFullNameMatching(
            IEnumerable<string> regexes
        )
        {
            return (type, _) =>
                regexes.Any(regex => Regex.IsMatch(type.Symbol.GetFullName(), regex));
        }

        internal static Func<TypeDefinition, StringComparison, bool> HaveFullNameNotMatching(
            IEnumerable<string> regexes
        )
        {
            return (type, _) => !HaveFullNameMatching(regexes)(type, _);
        }

        internal static Func<TypeDefinition, StringComparison, bool> HaveNameStartingWith(
            IEnumerable<string> name
        )
        {
            return (type, comparison) =>
                name.Any(n => type.Symbol.GetName().StartsWith(n, comparison));
        }

        internal static Func<TypeDefinition, StringComparison, bool> HaveNameEndingWith(
            IEnumerable<string> name
        )
        {
            return (type, comparison) =>
                name.Any(n => type.Symbol.GetName().EndsWith(n, comparison));
        }
    }
}
