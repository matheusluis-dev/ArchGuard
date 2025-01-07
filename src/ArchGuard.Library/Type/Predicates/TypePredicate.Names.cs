namespace ArchGuard.Library.Type.Predicates
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using ArchGuard.Library.Extensions;
    using ArchGuard.Library.Extensions.Type;

    internal static partial class TypePredicate
    {
        internal static Func<Type, StringComparison, bool> HaveName(params string[] name)
        {
            return (type, comparison) =>
                name.Contains(type.GetNameClean(), comparison.ToComparer());
        }

        internal static Func<Type, StringComparison, bool> HaveNameMatching(string regex)
        {
            var r = new Regex(regex, RegexOptions.IgnoreCase);
            return (type, _) => r.IsMatch(type.GetNameClean());
        }

        internal static Func<Type, StringComparison, bool> HaveNameNotMatching(string regex)
        {
            return (type, _) => !HaveNameMatching(regex)(type, _);
        }

        internal static Func<Type, StringComparison, bool> HaveFullName(params string[] name)
        {
            return (type, comparison) =>
                name.Contains(type.GetFullNameClean(), comparison.ToComparer());
        }

        internal static Func<Type, StringComparison, bool> HaveFullNameMatching(string regex)
        {
            var r = new Regex(regex, RegexOptions.IgnoreCase);
            return (type, _) => r.IsMatch(type.GetFullNameClean());
        }

        internal static Func<Type, StringComparison, bool> HaveFullNameNotMatching(string regex)
        {
            return (type, _) => !HaveFullNameMatching(regex)(type, _);
        }

        internal static Func<Type, StringComparison, bool> HaveNameStartingWith(
            params string[] name
        )
        {
            return (type, comparison) =>
                name.Any(n => type.GetNameClean().StartsWith(n, comparison));
        }

        internal static Func<Type, StringComparison, bool> HaveNameEndingWith(params string[] name)
        {
            return (type, comparison) => name.Any(n => type.GetNameClean().EndsWith(n, comparison));
        }
    }
}
