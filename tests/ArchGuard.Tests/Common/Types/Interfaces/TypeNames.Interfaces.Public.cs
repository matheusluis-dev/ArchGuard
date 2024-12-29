namespace ArchGuard.Tests.Common
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    internal static partial class TypeNames
    {
        internal static readonly ReadOnlyCollection<string> InterfacesPublic =
            new ReadOnlyCollection<string>(new List<string> { IPublicInterface });

        internal const string IPublicInterface =
            Namespaces.InterfacesPublic + "." + nameof(IPublicInterface);
    }
}
