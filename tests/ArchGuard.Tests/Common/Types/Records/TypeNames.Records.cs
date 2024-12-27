namespace ArchGuard.Tests.Common;

internal static partial class TypeNames
{
    internal static readonly ReadOnlyCollection<string> Records = new(
        [
            InternalPartialRecord,
            InternalRecord,
            InternalSealedRecord,
            PublicPartialRecord,
            PublicRecord,
            PublicSealedRecord,
        ]
    );
}
