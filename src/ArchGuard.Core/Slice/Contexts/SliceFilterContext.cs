namespace ArchGuard.Core.Slice.Contexts
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Core.Slice.Models;
    using ArchGuard.Core.Type.Contexts;

    public sealed class SliceFilterContext
    {
        private readonly TypeFilterContext _typeFilterContext;
        private string _namespace = string.Empty;

        public SliceFilterContext(TypeFilterContext typeFilterContext)
        {
            _typeFilterContext = typeFilterContext;
        }

        public void AddSlicesByNamespacePrefix(string @namespace)
        {
            ArgumentNullException.ThrowIfNull(@namespace);

            if (!string.IsNullOrEmpty(_namespace))
                throw new InvalidOperationException($"{nameof(_namespace)} already set.");

            _namespace = @namespace.EndsWith('.') ? @namespace : @namespace + '.';
        }

        public IEnumerable<SliceDefinition> GetSlices()
        {
            return GetSlices(Default.StringComparison);
        }

        public IEnumerable<SliceDefinition> GetSlices(StringComparison comparison)
        {
            var types = _typeFilterContext
                .GetTypes(comparison)
                .Where(type => type.Namespace.StartsWith(_namespace, comparison))
                .ToList();

            if (!string.IsNullOrEmpty(_namespace))
                throw new InvalidOperationException($"{nameof(_namespace)} not set.");

            if (types.Count == 0)
                return [];

            var elements = new HashSet<SliceDefinition>();
            foreach (var type in types)
                elements.Add(new SliceDefinition(type.Solution, type.Project, type.Namespace));

            return elements;
        }
    }
}
