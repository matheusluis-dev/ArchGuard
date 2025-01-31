namespace ArchGuard
{
    using System.Text.RegularExpressions;
    using ArchGuard.Kernel;

    internal static partial class MethodPredicate
    {
        public static Func<MethodDefinition, StringComparison, bool> HaveNamePascalCased =>
            (method, _) => Regex.IsMatch(method.Symbol.Name, RegularExpressions.PascalCase);
    }
}
