namespace ArchGuard.Tests.Common
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    internal static partial class TypeNames
    {
        internal static readonly ReadOnlyCollection<string> Records =
            new ReadOnlyCollection<string>(
                new List<string>
                {
#if NET5_0_OR_GREATER
                    InternalPartialRecord,
                    InternalRecord,
                    InternalSealedRecord,
                    PublicPartialRecord,
                    PublicRecord,
                    PublicSealedRecord,
#endif
                }
            );
    }
}
