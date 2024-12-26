namespace ArchGuard.Tests.Common;

internal static partial class TypeNames
{
    internal static readonly ReadOnlyCollection<string> Interfaces = new(
        [IInternalInterface, IPublicInterface]
    );
}
