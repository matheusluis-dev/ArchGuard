namespace ArchGuard.Tests.Common
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    internal static partial class TypeNames
    {
        internal static readonly ReadOnlyCollection<string> Structs =
            new ReadOnlyCollection<string>(new List<string> { InternalStruct, PublicStruct });
    }
}
