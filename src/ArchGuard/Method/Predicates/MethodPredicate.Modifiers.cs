namespace ArchGuard
{
    using ArchGuard.Kernel.Models;

    internal static partial class MethodPredicate
    {
        internal static Func<MethodDefinition, StringComparison, bool> Asynchronous =>
            (method, _) => method.Symbol.IsAsync;

        internal static Func<MethodDefinition, StringComparison, bool> NotAsynchronous =>
            (method, _) => !method.Symbol.IsAsync;
    }
}
