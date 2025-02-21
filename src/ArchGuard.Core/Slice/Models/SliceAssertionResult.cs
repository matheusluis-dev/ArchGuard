namespace ArchGuard.Core.Slice.Models
{
    using System.Collections.Generic;

    public sealed class SliceAssertionResult
    {
        public bool IsSuccessful => !NonCompliantSlices.Any();
        public IEnumerable<SliceDefinition> SlicesFiltered { get; }
        public IEnumerable<SliceDefinition> CompliantSlices { get; }
        public IEnumerable<SliceDefinition> NonCompliantSlices => SlicesFiltered.Except(CompliantSlices);

        internal SliceAssertionResult(
            IEnumerable<SliceDefinition> slicesFiltered,
            IEnumerable<SliceDefinition> slicesAsserted
        )
        {
            SlicesFiltered = slicesFiltered;
            CompliantSlices = slicesAsserted;
        }
    }
}
