namespace ArchGuard.Tests.Common;

internal static partial class TypeNames
{
    internal static readonly ReadOnlyCollection<string> EnumsPublic = new([PublicEnum]);

    internal const string PublicEnum = $"{Namespaces.EnumsPublic}.{nameof(PublicEnum)}";
}
