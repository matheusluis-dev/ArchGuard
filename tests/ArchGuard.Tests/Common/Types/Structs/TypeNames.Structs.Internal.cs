namespace ArchGuard.Tests.Common
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    internal static partial class TypeNames
    {
        internal static readonly ReadOnlyCollection<string> StructsInternal =
            new ReadOnlyCollection<string>(new List<string> { InternalStruct });

        internal const string InternalStruct =
            Namespaces.StructsInternal + "." + nameof(InternalStruct);
    }
}
