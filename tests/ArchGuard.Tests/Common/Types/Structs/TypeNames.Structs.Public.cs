namespace ArchGuard.Tests.Common;

internal static partial class TypeNames
{
    internal static readonly ReadOnlyCollection<string> StructsPublic = new([PublicStruct]);

    internal const string PublicStruct = $"{Namespaces.StructsPublic}.{nameof(PublicStruct)}";
}
