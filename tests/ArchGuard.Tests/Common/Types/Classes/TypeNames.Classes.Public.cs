namespace ArchGuard.Tests.Common;

internal static partial class TypeNames
{
    internal static readonly ReadOnlyCollection<string> ClassesPublic = new(
        [PublicClass, PublicPartialClass, PublicSealedClass, PublicStaticClass]
    );

    internal const string PublicClass = $"{Namespaces.ClassesPublic}.{nameof(PublicClass)}";
    internal const string PublicPartialClass =
        $"{Namespaces.ClassesPublic}.{nameof(PublicPartialClass)}";
    internal const string PublicSealedClass =
        $"{Namespaces.ClassesPublic}.{nameof(PublicSealedClass)}";
    internal const string PublicStaticClass =
        $"{Namespaces.ClassesPublic}.{nameof(PublicStaticClass)}";
}
