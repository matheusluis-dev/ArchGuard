namespace ArchGuard.Tests.Common;

internal static partial class TypeNames
{
    internal static readonly ReadOnlyCollection<string> Types = new(
        [
            InternalClass,
            InternalSealedClass,
            InternalStaticClass,
            PublicClass,
            PublicPartialClass,
            PublicSealedClass,
            PublicStaticClass,
            IInternalInterface,
            IPublicInterface,
            InternalPartialRecord,
            InternalRecord,
            InternalSealedRecord,
            PublicPartialRecord,
            PublicRecord,
            PublicSealedRecord,
            InternalStruct,
            PublicStruct,
        ]
    );
}
