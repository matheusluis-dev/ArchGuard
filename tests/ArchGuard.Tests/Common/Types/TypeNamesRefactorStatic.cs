namespace ArchGuard.Tests.Common.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class TypeNamesRefactorStatic
    {
        internal static IEnumerable<string> Classes
        {
            get
            {
                var list = new List<string>();

                list.AddRange(InternalClasses);
                list.AddRange(PublicClasses);

                return list.OrderBy(c => c, StringComparer.Ordinal);
            }
        }

        internal static readonly IEnumerable<string> PublicClasses = new List<string>
        {
            PublicClass,
            PublicPartialClass,
            PublicSealedClass,
            PublicStaticClass,
        }.OrderBy(c => c, StringComparer.Ordinal);

        internal static readonly IEnumerable<string> InternalClasses = new List<string>
        {
            InternalClass,
            InternalPartialClass,
            InternalSealedClass,
            InternalStaticClass,
        }.OrderBy(c => c, StringComparer.Ordinal);

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
}
