namespace ArchGuard.Tests.Common;

internal static partial class TypeNames
{
    internal static readonly ReadOnlyCollection<string> InterfacesPublic = new([IPublicInterface]);

    internal const string IPublicInterface =
        $"{Namespaces.InterfacesPublic}.{nameof(IPublicInterface)}";
}
