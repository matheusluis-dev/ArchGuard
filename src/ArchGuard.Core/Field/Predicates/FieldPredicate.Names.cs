namespace ArchGuard.Core.Field.Predicates
{
    using System.Text.RegularExpressions;
    using ArchGuard.Core.Field.Models;

    public static partial class FieldPredicate
    {
        public static Func<FieldDefinition, StringComparison, bool> HaveNamePascalCased =>
            (type, _) => Regex.IsMatch(type.Name, RegularExpressions.PascalCase);

        public static Func<FieldDefinition, StringComparison, bool> HaveNameCamelCased(string prefix)
        {
            return (type, _) => Regex.IsMatch(type.Name, RegularExpressions.CamelCase(prefix));
        }

        public static Func<FieldDefinition, StringComparison, bool> HaveNameCamelCased(char prefix)
        {
            return (type, _) => HaveNameCamelCased(prefix.ToString())(type, _);
        }
    }
}
