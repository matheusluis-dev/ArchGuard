namespace ArchGuard.Core.Predicates.Method
{
    using ArchGuard.Core.Method.Models;

    public static partial class MethodPredicate
    {
        public static Func<MethodDefinition, StringComparison, bool> Asynchronous =>
            (method, _) => method.IsAsync;

        public static Func<MethodDefinition, StringComparison, bool> NotAsynchronous =>
            (method, _) => !Asynchronous(method, _);

        public static Func<MethodDefinition, StringComparison, bool> Static =>
            (method, _) => method.IsStatic;

        public static Func<MethodDefinition, StringComparison, bool> NotStatic =>
            (method, _) => !Static(method, _);
    }
}
