namespace ArchGuard.Core.Field.Contexts
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Core.Field.Models;

    public sealed class FieldAssertionContext
    {
        private readonly List<List<Func<FieldDefinition, StringComparison, bool>>> _groupedPredicates = new();

        private readonly FieldFilterContext _fieldFilterContext;

        public FieldAssertionContext(FieldFilterContext fieldFilterContext)
        {
            _fieldFilterContext = fieldFilterContext;
        }

        private void CreateGroupedPredicate()
        {
            _groupedPredicates.Add(new());
        }

        public void AddPredicate(Func<FieldDefinition, StringComparison, bool> predicate)
        {
            if (_groupedPredicates.Count == 0)
                CreateGroupedPredicate();

            _groupedPredicates[^1].Add(predicate);
        }

        public void Or()
        {
            CreateGroupedPredicate();
        }

        private IEnumerable<FieldDefinition> GetFields(StringComparison comparison)
        {
            var methods = _fieldFilterContext.GetFields(comparison);

            if (_groupedPredicates.Count == 0)
                return methods;

            var elements = new HashSet<FieldDefinition>();
            foreach (var group in _groupedPredicates)
            {
                var elementsGrouped = methods.ToList().AsEnumerable();

                foreach (var predicate in group)
                    elementsGrouped = elementsGrouped.Where(type => predicate(type, comparison));

                elements.UnionWith(elementsGrouped);
            }

            return elements;
        }

        public FieldAssertionResult GetResult()
        {
            return GetResult(Default.StringComparison);
        }

        public FieldAssertionResult GetResult(StringComparison comparison)
        {
            var methodsFiltered = _fieldFilterContext.GetFields(comparison);
            var methodsAsserted = GetFields(comparison);

            return new FieldAssertionResult(methodsFiltered, methodsAsserted);
        }
    }
}
