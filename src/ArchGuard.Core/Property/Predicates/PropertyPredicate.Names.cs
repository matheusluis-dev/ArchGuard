namespace ArchGuard.Core.Property.Predicates
{
    using System.Text.RegularExpressions;
    using ArchGuard.Core.Property.Models;

    public static partial class PropertyPredicate
    {
        public static Func<PropertyDefinition, StringComparison, bool> HaveNamePascalCased =>
            (type, _) => Regex.IsMatch(type.Name, RegularExpressions.PascalCase);

        public static Func<PropertyDefinition, StringComparison, bool> HaveNameCamelCased(string prefix)
        {
            return (type, _) => Regex.IsMatch(type.Name, RegularExpressions.CamelCase(prefix));
        }

        public static Func<PropertyDefinition, StringComparison, bool> HaveNameCamelCased(char prefix)
        {
            return (type, _) => HaveNameCamelCased(prefix.ToString())(type, _);
        }
    }
}
