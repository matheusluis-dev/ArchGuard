namespace ArchGuard.Tests.Common
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    internal static partial class TypeNames
    {
        internal static readonly ReadOnlyCollection<string> EnumsInternal =
            new ReadOnlyCollection<string>(new List<string> { InternalEnum });

        internal const string InternalEnum = Namespaces.EnumsInternal + "." + nameof(InternalEnum);
    }
}
