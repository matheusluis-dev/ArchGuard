namespace ArchGuard.Tests.Common
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    internal static partial class TypeNames
    {
        internal static readonly ReadOnlyCollection<string> ClassesInternal =
            new ReadOnlyCollection<string>(
                new List<string>
                {
                    InternalClass,
                    InternalSealedClass,
                    InternalStaticClass,
#if NET5_0_OR_GREATER
                    "Microsoft.CodeAnalysis.EmbeddedAttribute",
                    "System.Runtime.CompilerServices.NullableAttribute",
                    "System.Runtime.CompilerServices.NullableContextAttribute",
#endif
                }
            );

        internal const string InternalClass =
            Namespaces.ClassesInternal + "." + nameof(InternalClass);

        internal const string InternalSealedClass =
            Namespaces.ClassesInternal + "." + nameof(InternalSealedClass);

        internal const string InternalStaticClass =
            Namespaces.ClassesInternal + "." + nameof(InternalStaticClass);
    }
}
