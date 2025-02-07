namespace ArchGuard.Core.Property.Contexts
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Core.Property.Models;
    using ArchGuard.Core.Type.Contexts;

    public sealed class PropertyFilterContext
    {
        private readonly List<
            List<Func<PropertyDefinition, StringComparison, bool>>
        > _groupedPredicates = new();

        private readonly TypeFilterContext _typeFilterContext;

        public PropertyFilterContext(TypeFilterContext typeFilterContext)
        {
            _typeFilterContext = typeFilterContext;
        }

        private void CreateGroupedPredicate()
        {
            _groupedPredicates.Add(new());
        }

        public void AddPredicate(Func<PropertyDefinition, StringComparison, bool> predicate)
        {
            if (_groupedPredicates.Count == 0)
                CreateGroupedPredicate();

            _groupedPredicates[^1].Add(predicate);
        }

        public void Or()
        {
            CreateGroupedPredicate();
        }

        public IEnumerable<PropertyDefinition> GetProperties()
        {
            return GetProperties(Default.StringComparison);
        }

        public IEnumerable<PropertyDefinition> GetProperties(StringComparison comparison)
        {
            var fields = _typeFilterContext
                .GetTypes(comparison)
                .SelectMany(type => type.GetProperties());

            if (_groupedPredicates.Count == 0)
                return fields;

            var elements = new HashSet<PropertyDefinition>();
            foreach (var group in _groupedPredicates)
            {
                var elementsGrouped = fields.ToList().AsEnumerable();

                foreach (var predicate in group)
                    elementsGrouped = elementsGrouped.Where(type => predicate(type, comparison));

                elements.UnionWith(elementsGrouped);
            }

            return elements;
        }
    }
}
