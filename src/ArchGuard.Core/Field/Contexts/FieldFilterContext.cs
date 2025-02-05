namespace ArchGuard.Core.Field.Contexts
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Core.Field.Models;
    using ArchGuard.Core.Type.Contexts;

    public sealed class FieldFilterContext
    {
        private readonly List<
            List<Func<FieldDefinition, StringComparison, bool>>
        > _groupedPredicates = new();

        private readonly TypeFilterContext _typeFilterContext;

        public FieldFilterContext(TypeFilterContext typeFilterContext)
        {
            _typeFilterContext = typeFilterContext;
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

        public IEnumerable<FieldDefinition> GetFields()
        {
            return GetFields(Default.StringComparison);
        }

        public IEnumerable<FieldDefinition> GetFields(StringComparison comparison)
        {
            var fields = _typeFilterContext
                .GetTypes(comparison)
                .SelectMany(type => type.GetFields());

            if (_groupedPredicates.Count == 0)
                return fields;

            var elements = new HashSet<FieldDefinition>();
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
