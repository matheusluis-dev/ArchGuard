// TODO: separate partials in different classes
namespace ArchGuard.Tests.Common.Types
{
    using ArchGuard.Tests.Common;

    public static partial class TypeNames { }

    public static partial class TypeNames
    {
        public const string InternalEnum = Namespaces.EnumsInternal + "." + nameof(InternalEnum);

        public const string PublicEnum = Namespaces.EnumsPublic + "." + nameof(PublicEnum);
    }

    public static partial class TypeNames
    {
        public const string IInternalInterface =
            Namespaces.InterfacesInternal + "." + nameof(IInternalInterface);

        public const string IPublicInterface =
            Namespaces.InterfacesPublic + "." + nameof(IPublicInterface);
    }

    public static partial class TypeNames
    {
        public const string FileClass = Namespaces.ClassesFile + "." + nameof(FileClass);

        public const string FilePartialClass =
            Namespaces.ClassesFile + "." + nameof(FilePartialClass);

        public const string FileSealedClass =
            Namespaces.ClassesFile + "." + nameof(FileSealedClass);

        public const string FileStaticClass =
            Namespaces.ClassesFile + "." + nameof(FileStaticClass);

        public const string InternalClass =
            Namespaces.ClassesInternal + "." + nameof(InternalClass);

        public const string InternalPartialClass =
            Namespaces.ClassesInternal + "." + nameof(InternalPartialClass);

        public const string InternalSealedClass =
            Namespaces.ClassesInternal + "." + nameof(InternalSealedClass);

        public const string InternalStaticClass =
            Namespaces.ClassesInternal + "." + nameof(InternalStaticClass);

        public const string PublicAbstractClass =
            Namespaces.ClassesPublic + "." + nameof(PublicAbstractClass);

        public const string PublicClass = Namespaces.ClassesPublic + "." + nameof(PublicClass);

        public const string PublicGenericClassWithOneType =
            Namespaces.ClassesPublic + "." + nameof(PublicGenericClassWithOneType);

        public const string PublicGenericClassWithTwoTypes =
            Namespaces.ClassesPublic + "." + nameof(PublicGenericClassWithTwoTypes);

        public const string PublicParentClass =
            Namespaces.ClassesPublic + "." + nameof(PublicParentClass);

        public const string PublicParentClass_PublicNestedClass =
            PublicParentClass + "+PublicNestedClass";

        public const string PublicParentClass_PublicNestedPartialClass =
            PublicParentClass + "+PublicNestedPartialClass";

        public const string PublicParentClass_InternalNestedClass =
            PublicParentClass + "+InternalNestedClass";

        public const string PublicParentClass_PrivateNestedClass =
            PublicParentClass + "+PrivateNestedClass";

        public const string PublicPartialClass =
            Namespaces.ClassesPublic + "." + nameof(PublicPartialClass);

        public const string PublicSealedClass =
            Namespaces.ClassesPublic + "." + nameof(PublicSealedClass);

        public const string PublicStaticClass =
            Namespaces.ClassesPublic + "." + nameof(PublicStaticClass);
    }

#if NET5_0_OR_GREATER
    public static partial class TypeNames
    {
        public const string InternalRecord =
            Namespaces.RecordsInternal + "." + nameof(InternalRecord);

        public const string InternalPartialRecord =
            Namespaces.RecordsInternal + "." + nameof(InternalPartialRecord);

        public const string InternalSealedRecord =
            Namespaces.RecordsInternal + "." + nameof(InternalSealedRecord);

        public const string PublicRecord = Namespaces.RecordsPublic + "." + nameof(PublicRecord);

        public const string PublicPartialRecord =
            Namespaces.RecordsPublic + "." + nameof(PublicPartialRecord);

        public const string PublicSealedRecord =
            Namespaces.RecordsPublic + "." + nameof(PublicSealedRecord);
    }
#endif

    public static partial class TypeNames
    {
        public const string InternalStruct =
            Namespaces.StructsInternal + "." + nameof(InternalStruct);

        public const string PublicStruct = Namespaces.StructsPublic + "." + nameof(PublicStruct);
    }
}
