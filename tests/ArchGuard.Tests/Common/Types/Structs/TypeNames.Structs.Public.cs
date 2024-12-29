namespace ArchGuard.Tests.Common
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    internal static partial class TypeNames
    {
        internal static readonly ReadOnlyCollection<string> StructsPublic =
            new ReadOnlyCollection<string>(new List<string> { PublicStruct });

        internal const string PublicStruct = Namespaces.StructsPublic + "." + nameof(PublicStruct);
    }
}
