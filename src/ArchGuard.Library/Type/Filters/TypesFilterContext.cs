namespace ArchGuard.Library.Type.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class TypesFilterContext
    {
        private readonly IEnumerable<TypeSpecRoslyn> _types;

        private readonly List<
            List<Func<TypeSpecRoslyn, StringComparison, bool>>
        > _groupedFilterPredicates = new List<List<Func<TypeSpecRoslyn, StringComparison, bool>>>();

        public TypesFilterContext(IEnumerable<TypeSpecRoslyn> types)
        {
            _types = types;
        }

        private void CreateGroupedPredicate()
        {
            _groupedFilterPredicates.Add(new List<Func<TypeSpecRoslyn, StringComparison, bool>>());
        }

        public void AddPredicate(Func<TypeSpecRoslyn, StringComparison, bool> predicate)
        {
            if (_groupedFilterPredicates.Count == 0)
                CreateGroupedPredicate();

            _groupedFilterPredicates[_groupedFilterPredicates.Count - 1].Add(predicate);
        }

        public void Or()
        {
            CreateGroupedPredicate();
        }

        internal List<List<Func<TypeSpecRoslyn, StringComparison, bool>>> GetFilters()
        {
            return _groupedFilterPredicates;
        }

        internal IEnumerable<TypeSpecRoslyn> GetRawTypes()
        {
            return _types;
        }

        public IEnumerable<TypeSpecRoslyn> GetTypes()
        {
            return GetTypes(StringComparison.CurrentCulture);
        }

        public IEnumerable<TypeSpecRoslyn> GetTypes(StringComparison comparison)
        {
            if (_groupedFilterPredicates.Count == 0)
                return _types;

            var types = new List<TypeSpecRoslyn>();

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
