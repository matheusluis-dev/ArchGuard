namespace ArchGuard.Tests.Common
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    internal static partial class TypeNames
    {
        internal static readonly ReadOnlyCollection<string> Interfaces =
            new ReadOnlyCollection<string>(
                new List<string> { IInternalInterface, IPublicInterface }
            );
    }
}
