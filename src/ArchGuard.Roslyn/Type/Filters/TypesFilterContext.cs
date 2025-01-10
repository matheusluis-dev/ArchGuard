namespace ArchGuard.Roslyn.Type.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.CodeAnalysis;

    public sealed class TypesFilterContext
    {
        private readonly IEnumerable<INamedTypeSymbol> _types;

        private readonly List<
            List<Func<INamedTypeSymbol, StringComparison, bool>>
        > _groupedFilterPredicates =
            new List<List<Func<INamedTypeSymbol, StringComparison, bool>>>();

        public TypesFilterContext(IEnumerable<INamedTypeSymbol> types)
        {
            _types = types;
        }

        private void CreateGroupedPredicate()
        {
            _groupedFilterPredicates.Add(
                new List<Func<INamedTypeSymbol, StringComparison, bool>>()
            );
        }

        public void AddPredicate(Func<INamedTypeSymbol, StringComparison, bool> predicate)
        {
            if (_groupedFilterPredicates.Count == 0)
                CreateGroupedPredicate();

            _groupedFilterPredicates[_groupedFilterPredicates.Count - 1].Add(predicate);
        }

        public void Or()
        {
            CreateGroupedPredicate();
        }

        internal List<List<Func<INamedTypeSymbol, StringComparison, bool>>> GetFilters()
        {
            return _groupedFilterPredicates;
        }

        internal IEnumerable<INamedTypeSymbol> GetRawTypes()
        {
            return _types;
        }

        public IEnumerable<INamedTypeSymbol> GetTypes()
        {
            return GetTypes(StringComparison.CurrentCulture);
        }

        public IEnumerable<INamedTypeSymbol> GetTypes(StringComparison comparison)
        {
            if (_groupedFilterPredicates.Count == 0)
                return _types;

            var types = new List<INamedTypeSymbol>();

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
