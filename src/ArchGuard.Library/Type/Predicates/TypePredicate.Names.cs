namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using ArchGuard.Library.Extensions;
    using ArchGuard.Library.Extensions.Type;

    internal static partial class TypePredicate
    {
        internal static Func<Type, StringComparison, bool> HaveName(IEnumerable<string> name)
        {
            return (type, comparison) =>
                name.Contains(type.GetNameClean(), comparison.ToComparer());
        }

        internal static Func<Type, StringComparison, bool> HaveNameMatching(
            IEnumerable<string> regexes
        )
        {
            return (type, _) => regexes.Any(regex => Regex.IsMatch(type.GetNameClean(), regex));
        }

        internal static Func<Type, StringComparison, bool> HaveNameNotMatching(
            IEnumerable<string> regex
        )
        {
            return (type, _) => !HaveNameMatching(regex)(type, _);
        }

        internal static Func<Type, StringComparison, bool> HaveFullName(IEnumerable<string> name)
        {
            return (type, comparison) =>
                name.Contains(type.GetFullNameClean(), comparison.ToComparer());
        }

        internal static Func<Type, StringComparison, bool> HaveFullNameMatching(
            IEnumerable<string> regexes
        )
        {
            return (type, _) => regexes.Any(regex => Regex.IsMatch(type.GetFullNameClean(), regex));
        }

        internal static Func<Type, StringComparison, bool> HaveFullNameNotMatching(
            IEnumerable<string> regexes
        )
        {
            return (type, _) => !HaveFullNameMatching(regexes)(type, _);
        }

        internal static Func<Type, StringComparison, bool> HaveNameStartingWith(
            IEnumerable<string> name
        )
        {
            return (type, comparison) =>
                name.Any(n => type.GetNameClean().StartsWith(n, comparison));
        }

        internal static Func<Type, StringComparison, bool> HaveNameEndingWith(
            IEnumerable<string> name
        )
        {
            return (type, comparison) => name.Any(n => type.GetNameClean().EndsWith(n, comparison));
        }
    }
}
