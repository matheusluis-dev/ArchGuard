namespace ArchGuard
{
    using System.Collections.Generic;
    using ArchGuard.Core.Slice.Models;

    public interface IGetSlices
    {
        IEnumerable<SliceDefinition> GetSlices();
        IEnumerable<SliceDefinition> GetSlices(StringComparison comparison);
    }
}
