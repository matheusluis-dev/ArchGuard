namespace ArchGuard.Tests.Common;

internal static partial class TypeNames
{
    internal static readonly ReadOnlyCollection<string> EnumsInternal = new([InternalEnum]);

    internal const string InternalEnum = $"{Namespaces.EnumsInternal}.{nameof(InternalEnum)}";
}
