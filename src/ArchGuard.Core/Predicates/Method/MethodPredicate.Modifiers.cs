namespace ArchGuard.Core.Predicates.Method
{
    public static partial class MethodPredicate
    {
        public static Func<MethodDefinition, StringComparison, bool> Asynchronous =>
            (method, _) => method.Symbol.IsAsync;

        public static Func<MethodDefinition, StringComparison, bool> NotAsynchronous =>
            (method, _) => !method.Symbol.IsAsync;

        public static Func<MethodDefinition, StringComparison, bool> Static =>
            (method, _) => method.Symbol.IsStatic;

        public static Func<MethodDefinition, StringComparison, bool> NotStatic =>
            (method, _) => !method.Symbol.IsStatic;
    }
}
