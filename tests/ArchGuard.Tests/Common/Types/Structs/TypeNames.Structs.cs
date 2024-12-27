namespace ArchGuard.Tests.Common;

internal static partial class TypeNames
{
    internal static readonly ReadOnlyCollection<string> Structs = new(
        [InternalStruct, PublicStruct]
    );
}
