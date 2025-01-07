namespace ArchGuard.Library.Type.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class TypesFilterContext
    {
        private readonly IEnumerable<Type> _types;

        private readonly List<List<Func<Type, StringComparison, bool>>> _groupedFilterPredicates =
            new List<List<Func<Type, StringComparison, bool>>>();

        public TypesFilterContext(IEnumerable<Type> types)
        {
            _types = types;
        }

        private void CreateGroupedPredicate()
        {
            _groupedFilterPredicates.Add(new List<Func<Type, StringComparison, bool>>());
        }

        public void AddPredicate(Func<Type, StringComparison, bool> predicate)
        {
            if (_groupedFilterPredicates.Count == 0)
                CreateGroupedPredicate();

            _groupedFilterPredicates[_groupedFilterPredicates.Count - 1].Add(predicate);
        }

        public void Or()
        {
            CreateGroupedPredicate();
        }

        internal List<List<Func<Type, StringComparison, bool>>> GetFilters()
        {
            return _groupedFilterPredicates;
        }

        internal IEnumerable<Type> GetRawTypes()
        {
            return _types;
        }

        public IEnumerable<Type> GetTypes()
        {
            return GetTypes(StringComparison.CurrentCulture);
        }

        public IEnumerable<Type> GetTypes(StringComparison comparison)
        {
            if (_groupedFilterPredicates.Count == 0)
                return _types;

            var types = new List<Type>();

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
