namespace ArchGuard.Library.Type.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.CodeAnalysis;

    public sealed class TypesFilterContext
    {
        private readonly SlnCompilation _slnCompilation;
        private readonly IEnumerable<TypeDefinition> _types;

        private readonly List<
            List<Func<TypeDefinition, StringComparison, bool>>
        > _groupedFilterPredicates = new();

        public TypesFilterContext(SlnCompilation slnCompilation)
        {
            ArgumentNullException.ThrowIfNull(slnCompilation);

            _slnCompilation = slnCompilation;
            _types = slnCompilation.Types;
        }

        private void CreateGroupedPredicate()
        {
            _groupedFilterPredicates.Add(new());
        }

        public void AddPredicate(Func<TypeDefinition, StringComparison, bool> predicate)
        {
            if (_groupedFilterPredicates.Count == 0)
                CreateGroupedPredicate();

            _groupedFilterPredicates[_groupedFilterPredicates.Count - 1].Add(predicate);
        }

        public void Or()
        {
            CreateGroupedPredicate();
        }

        internal List<List<Func<TypeDefinition, StringComparison, bool>>> GetFilters()
        {
            return _groupedFilterPredicates;
        }

        internal IEnumerable<TypeDefinition> GetRawTypes()
        {
            return _types;
        }

        public IEnumerable<TypeDefinition> GetTypes()
        {
            return GetTypes(StringComparison.CurrentCulture);
        }

        public IEnumerable<TypeDefinition> GetTypes(StringComparison comparison)
        {
            if (_groupedFilterPredicates.Count == 0)
                return _types;

            var types = new List<TypeDefinition>();

            foreach (var group in _groupedFilterPredicates)
            {
                var typesGrouped = _types;
                foreach (var predicate in group)
                {
                    typesGrouped = typesGrouped.Where(type => predicate(type, comparison));
                }

                types.AddRange(typesGrouped);
            }

            return types.Distinct();
        }
    }
}
