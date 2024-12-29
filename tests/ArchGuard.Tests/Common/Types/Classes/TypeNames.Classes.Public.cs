namespace ArchGuard.Tests.Common
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    internal static partial class TypeNames
    {
        internal static readonly ReadOnlyCollection<string> ClassesPublic =
            new ReadOnlyCollection<string>(
                new List<string>
                {
                    PublicClass,
                    PublicPartialClass,
                    PublicSealedClass,
                    PublicStaticClass,
                }
            );

        internal const string PublicClass = Namespaces.ClassesPublic + "." + nameof(PublicClass);

        internal const string PublicPartialClass =
            Namespaces.ClassesPublic + "." + nameof(PublicPartialClass);

        internal const string PublicSealedClass =
            Namespaces.ClassesPublic + "." + nameof(PublicSealedClass);

        internal const string PublicStaticClass =
            Namespaces.ClassesPublic + "." + nameof(PublicStaticClass);
    }
}
