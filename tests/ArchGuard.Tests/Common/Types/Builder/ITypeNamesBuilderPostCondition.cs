namespace ArchGuard.Tests.Common.Types.Builder
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal interface ITypeNamesBuilderPostCondition
    {
        ITypeNamesBuilderCondition And();
        ITypeNamesBuilderPostCondition And(
            Func<ITypeNamesBuilderCondition, ITypeNamesBuilderPostCondition> filter
        );

        ITypeNamesBuilderCondition Or();
        ITypeNamesBuilderPostCondition Or(
            Func<ITypeNamesBuilderCondition, ITypeNamesBuilderPostCondition> filter
        );

        List<string> GetTypeNames();
    }
}
