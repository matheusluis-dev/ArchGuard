namespace ArchGuard.Core.Property.Contexts
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Core.Property.Models;

    public sealed class PropertyAssertionContext
    {
        private readonly List<List<Func<PropertyDefinition, StringComparison, bool>>> _groupedPredicates = new();

        private readonly PropertyFilterContext _propertyFilterContext;

        public PropertyAssertionContext(PropertyFilterContext propertyFilterContext)
        {
            _propertyFilterContext = propertyFilterContext;
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

        private IEnumerable<PropertyDefinition> GetProperties(StringComparison comparison)
        {
            var methods = _propertyFilterContext.GetProperties(comparison);

            if (_groupedPredicates.Count == 0)
                return methods;

            var elements = new HashSet<PropertyDefinition>();
            foreach (var group in _groupedPredicates)
            {
                var elementsGrouped = methods.ToList().AsEnumerable();

                foreach (var predicate in group)
                    elementsGrouped = elementsGrouped.Where(type => predicate(type, comparison));

                elements.UnionWith(elementsGrouped);
            }

            return elements;
        }

        public PropertyAssertionResult GetResult()
        {
            return GetResult(Default.StringComparison);
        }

        public PropertyAssertionResult GetResult(StringComparison comparison)
        {
            var methodsFiltered = _propertyFilterContext.GetProperties(comparison);
            var methodsAsserted = GetProperties(comparison);

            return new PropertyAssertionResult(methodsFiltered, methodsAsserted);
        }
    }
}
