namespace ArchGuard.Library.Type.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class TypesFilterContext
    {
        private readonly IEnumerable<Type> _types;

        private readonly List<List<Func<Type, bool>>> _groupedFilterPredicates =
            new List<List<Func<Type, bool>>>();

        public TypesFilterContext(IEnumerable<Type> types)
        {
            _types = types;
        }

        private void CreateGroupedPredicate()
        {
            _groupedFilterPredicates.Add(new List<Func<Type, bool>>());
        }

        public void AddPredicate(Func<Type, bool> predicate)
        {
            if (_groupedFilterPredicates.Count == 0)
                CreateGroupedPredicate();

            _groupedFilterPredicates[_groupedFilterPredicates.Count - 1].Add(predicate);
        }

        public void Or()
        {
            CreateGroupedPredicate();
        }

        internal List<List<Func<Type, bool>>> GetFilters()
        {
            return _groupedFilterPredicates;
        }

        internal IEnumerable<Type> GetRawTypes()
        {
            return _types;
        }

        public IEnumerable<Type> GetTypes()
        {
            if (_groupedFilterPredicates.Count == 0)
                return _types;

            var types = new List<Type>();

            foreach (var group in _groupedFilterPredicates)
            {
                var typesGrouped = _types;
                foreach (var predicate in group)
                {
                    typesGrouped = typesGrouped.Where(predicate);
                }

                types.AddRange(typesGrouped);
            }

            return types.Distinct();
        }
    }
}
