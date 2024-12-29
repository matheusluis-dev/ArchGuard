namespace ArchGuard.Library.Types.Filters.Conditions.Interfaces
{
    using System;
    using ArchGuard.Library.Types.Filters.PostConditions.Interfaces;

    public partial interface ITypesFilterConditions
    {
        ITypesFilterPostConditions HaveNameStartingWith(string name);
        ITypesFilterPostConditions HaveNameStartingWith(string name, StringComparison comparison);

        ITypesFilterPostConditions HaveNameEndingWith(string name);
        ITypesFilterPostConditions HaveNameEndingWith(string name, StringComparison comparison);
    }
}
