namespace ArchGuard.Tests.Common;

internal static partial class TypeNames
{
    internal static readonly ReadOnlyCollection<string> RecordsPublic = new(
        [PublicPartialRecord, PublicRecord, PublicSealedRecord]
    );

    internal const string PublicRecord = $"{Namespaces.RecordsPublic}.{nameof(PublicRecord)}";
    internal const string PublicPartialRecord =
        $"{Namespaces.RecordsPublic}.{nameof(PublicPartialRecord)}";
    internal const string PublicSealedRecord =
        $"{Namespaces.RecordsPublic}.{nameof(PublicSealedRecord)}";
}
