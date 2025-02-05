namespace ArchGuard.Core.Predicates.Method
{
    using ArchGuard.Core.Method.Models;

    public static partial class MethodPredicate
    {
        public static Func<MethodDefinition, StringComparison, bool> Asynchronous =>
            (method, _) => method._method.IsAsync;

        public static Func<MethodDefinition, StringComparison, bool> NotAsynchronous =>
            (method, _) => !method._method.IsAsync;

        public static Func<MethodDefinition, StringComparison, bool> Static =>
            (method, _) => method._method.IsStatic;

        public static Func<MethodDefinition, StringComparison, bool> NotStatic =>
            (method, _) => !method._method.IsStatic;
    }
}
