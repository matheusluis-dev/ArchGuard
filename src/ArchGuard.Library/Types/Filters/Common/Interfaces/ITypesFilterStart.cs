namespace ArchGuard.Library.Types.Filters.Common.Interfaces
{
    using System;
    using ArchGuard.Library.Types.Filters.Conditions.Interfaces;
    using ArchGuard.Library.Types.Filters.PostConditions.Interfaces;

    public interface ITypesFilterStart : IGetTypes
    {
        ITypesFilterConditions That();
        ITypesFilterPostConditions That(
            Func<ITypesFilterConditions, ITypesFilterPostConditions> filter
        );
    }
}
