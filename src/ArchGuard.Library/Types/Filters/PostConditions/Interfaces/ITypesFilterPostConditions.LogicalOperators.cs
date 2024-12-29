namespace ArchGuard.Library.Types.Filters.PostConditions.Interfaces
{
    using System;
    using ArchGuard.Library.Types.Filters.Conditions.Interfaces;

    public partial interface ITypesFilterPostConditions
    {
        ITypesFilterConditions And();
        ITypesFilterPostConditions And(
            Func<ITypesFilterConditions, ITypesFilterPostConditions> filter
        );

        ITypesFilterConditions Or();
        ITypesFilterPostConditions Or(
            Func<ITypesFilterConditions, ITypesFilterPostConditions> filter
        );
    }
}
