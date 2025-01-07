namespace ArchGuard.Library.Type
{
    using System;

    internal static class EngineOptions
    {
        internal static StringComparison StringComparison { get; set; } =
            StringComparison.CurrentCulture;
        internal static StringComparer StringComparer { get; set; } = StringComparer.CurrentCulture;
    }
}
