namespace ArchGuard.Library.Type.Filters.Common.Interfaces
{
    using System;
    using ArchGuard.Library.Type.Filters.Conditions.Interfaces;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

    public interface ITypesFilterStart : IGetTypes
    {
        ITypesFilterConditions That();
        ITypesFilterPostConditions That(
            Func<ITypesFilterConditions, ITypesFilterPostConditions> filter
        );
    }
}
