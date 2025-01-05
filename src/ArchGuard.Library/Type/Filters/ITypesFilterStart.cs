namespace ArchGuard.Library.Type.Filters
{
    using System;
    using ArchGuard.Library.Type;
    using ArchGuard.Library.Type.Filters.Conditions.Interfaces;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

    public interface ITypesFilterStart : IGetTypes
    {
        ITypesFilterConditions That { get; }
    }
}
