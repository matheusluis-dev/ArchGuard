namespace ArchGuard.Tests.Common
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    internal static partial class TypeNames
    {
        internal static readonly ReadOnlyCollection<string> InterfacesInternal =
            new ReadOnlyCollection<string>(new List<string> { IInternalInterface });

        internal const string IInternalInterface =
            Namespaces.InterfacesInternal + "." + nameof(IInternalInterface);
    }
}
