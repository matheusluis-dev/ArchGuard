namespace ArchGuard.Tests.Common.Types.Builder
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal interface ITypeNamesBuilderStart
    {
        ITypeNamesBuilderPostCondition That();
        ITypeNamesBuilderPostCondition That(
            Func<ITypeNamesBuilderPostCondition, ITypeNamesBuilderPostCondition> filter
        );
    }
}
