namespace ArchGuard.Tests.Common.Types.Builder
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal interface ITypeNamesBuilderCondition
    {
        ITypeNamesBuilderPostCondition AreClasses();
        ITypeNamesBuilderPostCondition AreNotClasses();

        ITypeNamesBuilderPostCondition AreEnums();
        ITypeNamesBuilderPostCondition AreNotEnums();

        ITypeNamesBuilderPostCondition AreInterfaces();
        ITypeNamesBuilderPostCondition AreNotInterfaces();

        ITypeNamesBuilderPostCondition AreRecords();
        ITypeNamesBuilderPostCondition AreNotRecords();

        ITypeNamesBuilderPostCondition ArePublic();
        ITypeNamesBuilderPostCondition AreNotPublic();

        ITypeNamesBuilderPostCondition AreInternal();
        ITypeNamesBuilderPostCondition AreNotInternal();

        ITypeNamesBuilderPostCondition ArePartial();
        ITypeNamesBuilderPostCondition AreNotPartial();

        ITypeNamesBuilderPostCondition AreSealed();
        ITypeNamesBuilderPostCondition AreNotSealed();

        ITypeNamesBuilderPostCondition ResideInNamespace(string name);
        ITypeNamesBuilderPostCondition ResideInNamespace(string name, StringComparison comparison);
        ITypeNamesBuilderPostCondition NotResideInNamespace(string name);
        ITypeNamesBuilderPostCondition NotResideInNamespace(
            string name,
            StringComparison comparison
        );

        ITypeNamesBuilderPostCondition HaveNameStartingWith(string start);
        ITypeNamesBuilderPostCondition HaveNameStartingWith(
            string start,
            StringComparison comparison
        );
        ITypeNamesBuilderPostCondition HaveNameEndingWith(string end);
        ITypeNamesBuilderPostCondition HaveNameEndingWith(string end, StringComparison comparison);
    }
}
