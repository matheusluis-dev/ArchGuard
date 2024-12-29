namespace ArchGuard.Tests.Common
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    internal static partial class TypeNames
    {
        internal static readonly ReadOnlyCollection<string> RecordsInternal =
            new ReadOnlyCollection<string>(
                new List<string>
                {
#if NET5_0_OR_GREATER
                    InternalPartialRecord,
                    InternalRecord,
                    InternalSealedRecord
#endif
                }
            );

        internal const string InternalRecord =
            Namespaces.RecordsInternal + "." + nameof(InternalRecord);

        internal const string InternalPartialRecord =
            Namespaces.RecordsInternal + "." + nameof(InternalPartialRecord);

        internal const string InternalSealedRecord =
            Namespaces.RecordsInternal + "." + nameof(InternalSealedRecord);
    }
}
