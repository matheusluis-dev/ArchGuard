namespace ArchGuard.Tests.Common
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    internal static partial class TypeNames
    {
        internal static readonly ReadOnlyCollection<string> EnumsPublic =
            new ReadOnlyCollection<string>(new List<string> { PublicEnum });

        internal const string PublicEnum = Namespaces.EnumsPublic + "." + nameof(PublicEnum);
    }
}
