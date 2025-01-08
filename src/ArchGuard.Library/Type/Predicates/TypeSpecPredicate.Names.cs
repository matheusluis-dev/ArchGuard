namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using ArchGuard.Library.Extensions;
    using ArchGuard.Library.Extensions.Type;

    internal static partial class TypeSpecPredicate
    {
        internal static Func<TypeSpec, StringComparison, bool> HaveName(IEnumerable<string> name)
        {
            return (type, comparison) =>
                name.Contains(type.ReflectionType.GetNameClean(), comparison.ToComparer());
        }

        internal static Func<TypeSpec, StringComparison, bool> HaveNameMatching(
            IEnumerable<string> regexes
        )
        {
            return (type, _) =>
                regexes.Any(regex => Regex.IsMatch(type.ReflectionType.GetNameClean(), regex));
        }

        internal static Func<TypeSpec, StringComparison, bool> HaveNameNotMatching(
            IEnumerable<string> regex
        )
        {
            return (type, _) => !HaveNameMatching(regex)(type, _);
        }

        internal static Func<TypeSpec, StringComparison, bool> HaveFullName(
            IEnumerable<string> name
        )
        {
            return (type, comparison) =>
                name.Contains(type.ReflectionType.GetFullNameClean(), comparison.ToComparer());
        }

        internal static Func<TypeSpec, StringComparison, bool> HaveFullNameMatching(
            IEnumerable<string> regexes
        )
        {
            return (type, _) =>
                regexes.Any(regex => Regex.IsMatch(type.ReflectionType.GetFullNameClean(), regex));
        }

        internal static Func<TypeSpec, StringComparison, bool> HaveFullNameNotMatching(
            IEnumerable<string> regexes
        )
        {
            return (type, _) => !HaveFullNameMatching(regexes)(type, _);
        }

        internal static Func<TypeSpec, StringComparison, bool> HaveNameStartingWith(
            IEnumerable<string> name
        )
        {
            return (type, comparison) =>
                name.Any(n => type.ReflectionType.GetNameClean().StartsWith(n, comparison));
        }

        internal static Func<TypeSpec, StringComparison, bool> HaveNameEndingWith(
            IEnumerable<string> name
        )
        {
            return (type, comparison) =>
                name.Any(n => type.ReflectionType.GetNameClean().EndsWith(n, comparison));
        }
    }
}
