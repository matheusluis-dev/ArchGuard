namespace ArchGuard.Tests.Common;

internal static partial class TypeNames
{
    internal static readonly ReadOnlyCollection<string> StructsInternal = new([InternalStruct]);

    internal const string InternalStruct = $"{Namespaces.StructsInternal}.{nameof(InternalStruct)}";
}
