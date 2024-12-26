namespace ArchGuard.Tests.Common;

internal static partial class TypeNames
{
    internal static readonly ReadOnlyCollection<string> ClassesInternal = new(
        [InternalClass, InternalSealedClass, InternalStaticClass]
    );

    internal const string InternalClass = $"{Namespaces.ClassesInternal}.{nameof(InternalClass)}";
    internal const string InternalSealedClass =
        $"{Namespaces.ClassesInternal}.{nameof(InternalSealedClass)}";
    internal const string InternalStaticClass =
        $"{Namespaces.ClassesInternal}.{nameof(InternalStaticClass)}";
}
