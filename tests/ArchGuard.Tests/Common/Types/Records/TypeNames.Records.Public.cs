namespace ArchGuard.Tests.Common
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    internal static partial class TypeNames
    {
        internal static readonly ReadOnlyCollection<string> RecordsPublic =
            new ReadOnlyCollection<string>(
                new List<string>
                {
#if NET5_0_OR_GREATER
                    PublicPartialRecord,
                    PublicRecord,
                    PublicSealedRecord
#endif
                }
            );

        internal const string PublicRecord = Namespaces.RecordsPublic + "." + nameof(PublicRecord);

        internal const string PublicPartialRecord =
            Namespaces.RecordsPublic + "." + nameof(PublicPartialRecord);

        internal const string PublicSealedRecord =
            Namespaces.RecordsPublic + "." + nameof(PublicSealedRecord);
    }
}
