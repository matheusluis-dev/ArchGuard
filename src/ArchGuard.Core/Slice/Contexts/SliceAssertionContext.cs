namespace ArchGuard.Core.Slice.Contexts
{
    using System;
    using ArchGuard.Core.Extensions;
    using ArchGuard.Core.Slice.Models;

    public sealed class SliceAssertionContext
    {
        private readonly SliceFilterContext _sliceFilterContext;

        public SliceAssertionContext(SliceFilterContext sliceFilterContext)
        {
            _sliceFilterContext = sliceFilterContext;
        }

        public SliceAssertionResult GetResult()
        {
            return GetResult(Default.StringComparison);
        }

        public SliceAssertionResult GetResult(StringComparison comparison)
        {
            var slices = _sliceFilterContext.GetSlices(comparison).ToList();
            var compliantSlices = new HashSet<SliceDefinition>();

            var namespaces = slices.Select(slice => slice.Namespace);

            foreach (var slice in slices)
            {
                var compliant = slice
                    .DependenciesForEachType.SelectMany(dependency => dependency.Value)
                    .Select(type => type.Namespace)
                    .All(@namespace => !namespaces.Contains(@namespace, comparison.ToComparer()));

                if (compliant)
                    compliantSlices.Add(slice);
            }

            return new SliceAssertionResult(slices, compliantSlices);
        }
    }
}
