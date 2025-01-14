namespace ArchGuard.Library.Type.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.CodeAnalysis;

    public sealed class TypesFilterContext
    {
        private readonly SlnCompilation _slnCompilation;
        private readonly IEnumerable<Type_> _types;

        private readonly List<List<Func<Type_, StringComparison, bool>>> _groupedFilterPredicates =
            new();

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

        public void AddPredicate(Func<Type_, StringComparison, bool> predicate)
        {
            if (_groupedFilterPredicates.Count == 0)
                CreateGroupedPredicate();

            _groupedFilterPredicates[_groupedFilterPredicates.Count - 1].Add(predicate);
        }

        public void Or()
        {
            CreateGroupedPredicate();
        }

        internal List<List<Func<Type_, StringComparison, bool>>> GetFilters()
        {
            return _groupedFilterPredicates;
        }

        internal IEnumerable<Type_> GetRawTypes()
        {
            return _types;
        }

        public IEnumerable<Type_> GetTypes()
        {
            return GetTypes(StringComparison.CurrentCulture);
        }

        public IEnumerable<Type_> GetTypes(StringComparison comparison)
        {
            if (_groupedFilterPredicates.Count == 0)
                return _types;

            var types = new List<Type_>();

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
