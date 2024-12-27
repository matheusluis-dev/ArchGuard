namespace ArchGuard.Tests.Common;

internal static partial class TypeNames
{
    internal static readonly ReadOnlyCollection<string> RecordsInternal = new(
        [InternalPartialRecord, InternalRecord, InternalSealedRecord]
    );

    internal const string InternalRecord = $"{Namespaces.RecordsInternal}.{nameof(InternalRecord)}";
    internal const string InternalPartialRecord =
        $"{Namespaces.RecordsInternal}.{nameof(InternalPartialRecord)}";
    internal const string InternalSealedRecord =
        $"{Namespaces.RecordsInternal}.{nameof(InternalSealedRecord)}";
}
