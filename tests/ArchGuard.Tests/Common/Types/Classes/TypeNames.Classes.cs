namespace ArchGuard.Tests.Common
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    internal static partial class TypeNames
    {
        internal static readonly ReadOnlyCollection<string> Classes =
            new ReadOnlyCollection<string>(
                new List<string>
                {
                    InternalClass,
                    InternalSealedClass,
                    InternalStaticClass,
                    PublicClass,
                    PublicPartialClass,
                    PublicSealedClass,
                    PublicStaticClass,
#if NET5_0_OR_GREATER
                    "Microsoft.CodeAnalysis.EmbeddedAttribute",
                    "System.Runtime.CompilerServices.NullableAttribute",
                    "System.Runtime.CompilerServices.NullableContextAttribute",
#endif
                }
            );
    }
}
