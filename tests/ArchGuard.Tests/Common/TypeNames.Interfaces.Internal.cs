namespace ArchGuard.Tests.Common;

internal static partial class TypeNames
{
    internal static readonly ReadOnlyCollection<string> InterfacesInternal = new(
        [IInternalInterface]
    );

    internal const string IInternalInterface =
        $"{Namespaces.InterfacesInternal}.{nameof(IInternalInterface)}";
}
