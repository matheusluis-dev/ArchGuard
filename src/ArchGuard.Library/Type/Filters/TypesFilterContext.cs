namespace ArchGuard.Library.Type.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class TypesFilterContext
    {
        private readonly IEnumerable<TypeSpec> _types;

        private readonly List<
            List<Func<TypeSpec, StringComparison, bool>>
        > _groupedFilterPredicates = new List<List<Func<TypeSpec, StringComparison, bool>>>();

        public TypesFilterContext(IEnumerable<TypeSpec> types)
        {
            _types = types;
        }

        private void CreateGroupedPredicate()
        {
            _groupedFilterPredicates.Add(new List<Func<TypeSpec, StringComparison, bool>>());
        }

        public void AddPredicate(Func<TypeSpec, StringComparison, bool> predicate)
        {
            if (_groupedFilterPredicates.Count == 0)
                CreateGroupedPredicate();

            _groupedFilterPredicates[_groupedFilterPredicates.Count - 1].Add(predicate);
        }

        public void Or()
        {
            CreateGroupedPredicate();
        }

        internal List<List<Func<TypeSpec, StringComparison, bool>>> GetFilters()
        {
            return _groupedFilterPredicates;
        }

        internal IEnumerable<TypeSpec> GetRawTypes()
        {
            return _types;
        }

        public IEnumerable<TypeSpec> GetTypes()
        {
            return GetTypes(StringComparison.CurrentCulture);
        }

        public IEnumerable<TypeSpec> GetTypes(StringComparison comparison)
        {
            if (_groupedFilterPredicates.Count == 0)
                return _types;

            var types = new List<TypeSpec>();

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
