namespace ArchGuard.Core.Predicates.Type
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using ArchGuard.Core.Extensions;
    using ArchGuard.Core.Type.Models;
    using Microsoft.CodeAnalysis;

    public static partial class TypePredicate
    {
        public static Func<TypeDefinition, StringComparison, bool> HaveName(IEnumerable<string> names)
        {
            return (type, comparison) => names.Contains(type.Name, comparison.ToComparer());
        }

        public static Func<TypeDefinition, StringComparison, bool> HaveNameMatching(IEnumerable<string> regexes)
        {
            return (type, _) => regexes.Any(regex => Regex.IsMatch(type.Name, regex));
        }

        public static Func<TypeDefinition, StringComparison, bool> HaveNameNotMatching(IEnumerable<string> regex)
        {
            return (type, _) => !HaveNameMatching(regex)(type, _);
        }

        public static Func<TypeDefinition, StringComparison, bool> HaveFullName(IEnumerable<string> name)
        {
            return (type, comparison) => name.Contains(type.FullName, comparison.ToComparer());
        }

        public static Func<TypeDefinition, StringComparison, bool> HaveFullNameMatching(IEnumerable<string> regexes)
        {
            return (type, _) => regexes.Any(regex => Regex.IsMatch(type.FullName, regex));
        }

        public static Func<TypeDefinition, StringComparison, bool> HaveFullNameNotMatching(IEnumerable<string> regexes)
        {
            return (type, _) => !HaveFullNameMatching(regexes)(type, _);
        }

        public static Func<TypeDefinition, StringComparison, bool> HaveNameStartingWith(IEnumerable<string> name)
        {
            return (type, comparison) => name.Any(n => type.Name.StartsWith(n, comparison));
        }

        public static Func<TypeDefinition, StringComparison, bool> NotHaveNameStartingWith(IEnumerable<string> name)
        {
            return (type, comparison) => !name.Any(n => type.Name.StartsWith(n, comparison));
        }

        public static Func<TypeDefinition, StringComparison, bool> HaveNameEndingWith(IEnumerable<string> name)
        {
            return (type, comparison) => name.Any(n => type.Name.EndsWith(n, comparison));
        }

        public static Func<TypeDefinition, StringComparison, bool> NotHaveNameEndingWith(IEnumerable<string> name)
        {
            return (type, comparison) => name.Any(n => !type.Name.EndsWith(n, comparison));
        }

        public static Func<TypeDefinition, StringComparison, bool> HaveNamePascalCased =>
            (type, _) => Regex.IsMatch(type.Name, RegularExpressions.PascalCase);
    }
}
