namespace ArchGuard.Library.Type.Filters.Conditions.Interfaces
{
    using System;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

    public partial interface ITypesFilterConditions
    {
        ITypesFilterPostConditions HaveNameStartingWith(string name);
        ITypesFilterPostConditions HaveNameStartingWith(string name, StringComparison comparison);

        ITypesFilterPostConditions HaveNameEndingWith(string name);
        ITypesFilterPostConditions HaveNameEndingWith(string name, StringComparison comparison);
    }
}
