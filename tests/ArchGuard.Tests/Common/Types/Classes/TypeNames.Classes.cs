namespace ArchGuard.Tests.Common;

internal static partial class TypeNames
{
    internal static readonly ReadOnlyCollection<string> Classes = new(
        [
            InternalClass,
            InternalSealedClass,
            InternalStaticClass,
            PublicClass,
            PublicPartialClass,
            PublicSealedClass,
            PublicStaticClass,
        ]
    );
}
