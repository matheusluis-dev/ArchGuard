namespace ArchGuard.Tests.Common.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static partial class TypeNames { }

    internal static partial class TypeNames
    {
        internal const string InternalEnum = Namespaces.EnumsInternal + "." + nameof(InternalEnum);

        internal const string PublicEnum = Namespaces.EnumsPublic + "." + nameof(PublicEnum);
    }

    internal static partial class TypeNames
    {
        internal const string IInternalInterface =
            Namespaces.InterfacesInternal + "." + nameof(IInternalInterface);

        internal const string IPublicInterface =
            Namespaces.InterfacesPublic + "." + nameof(IPublicInterface);
    }

    internal static partial class TypeNames
    {
        internal const string InternalClass =
            Namespaces.ClassesInternal + "." + nameof(InternalClass);

        internal const string InternalPartialClass =
            Namespaces.ClassesInternal + "." + nameof(InternalPartialClass);

        internal const string InternalSealedClass =
            Namespaces.ClassesInternal + "." + nameof(InternalSealedClass);

        internal const string InternalStaticClass =
            Namespaces.ClassesInternal + "." + nameof(InternalStaticClass);

        internal const string PublicClass = Namespaces.ClassesPublic + "." + nameof(PublicClass);

        internal const string PublicPartialClass =
            Namespaces.ClassesPublic + "." + nameof(PublicPartialClass);

        internal const string PublicSealedClass =
            Namespaces.ClassesPublic + "." + nameof(PublicSealedClass);

        internal const string PublicStaticClass =
            Namespaces.ClassesPublic + "." + nameof(PublicStaticClass);
    }

#if NET5_0_OR_GREATER
    internal static partial class TypeNames
    {
        internal const string InternalRecord =
            Namespaces.RecordsInternal + "." + nameof(InternalRecord);

        internal const string InternalPartialRecord =
            Namespaces.RecordsInternal + "." + nameof(InternalPartialRecord);

        internal const string InternalSealedRecord =
            Namespaces.RecordsPublic + "." + nameof(PublicSealedRecord);

        internal const string PublicRecord = Namespaces.RecordsPublic + "." + nameof(PublicRecord);

        internal const string PublicPartialRecord =
            Namespaces.RecordsPublic + "." + nameof(PublicPartialRecord);

        internal const string PublicSealedRecord =
            Namespaces.RecordsPublic + "." + nameof(PublicSealedRecord);
    }
#endif

    internal static partial class TypeNames
    {
        internal const string InternalStruct =
            Namespaces.StructsInternal + "." + nameof(InternalStruct);

        internal const string PublicStruct = Namespaces.StructsPublic + "." + nameof(PublicStruct);
    }
}
