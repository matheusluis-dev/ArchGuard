namespace ArchGuard.Library.Type.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Library.Type.Assertions;

    public sealed class TypesFilterContext
    {
        private readonly IEnumerable<Type> _types;

        private readonly List<List<Func<Type, bool>>> _groupedFilterPredicates =
            new List<List<Func<Type, bool>>>();

        private readonly List<List<Func<Type, bool>>> _groupedAssertionPredicates =
            new List<List<Func<Type, bool>>>();

        private FilterTypeStage _filterTypeStage = FilterTypeStage.Filtering;

        private List<List<Func<Type, bool>>> GroupedPredicates =>
            _filterTypeStage == FilterTypeStage.Filtering
                ? _groupedFilterPredicates
                : _groupedAssertionPredicates;

        public TypesFilterContext(IEnumerable<Type> types)
        {
            _types = types;
        }

        public void StartAssertions()
        {
            _filterTypeStage = FilterTypeStage.Asserting;
        }

        private void CreateGroupedPredicate()
        {
            GroupedPredicates.Add(new List<Func<Type, bool>>());
        }

        public void AddPredicate(Func<Type, bool> predicate)
        {
            if (GroupedPredicates.Count == 0)
                CreateGroupedPredicate();

            GroupedPredicates[GroupedPredicates.Count - 1].Add(predicate);
        }

        public void Or()
        {
            CreateGroupedPredicate();
        }

        public TypesAssertionResult GetResult()
        {
            var typesFiltered = GetTypes();

            var typesAsserted = new List<Type>();
            foreach (var group in _groupedAssertionPredicates)
            {
                var typesGrouped = _types;
                foreach (var predicate in group)
                {
                    typesGrouped = typesGrouped.Where(predicate);
                }

                typesAsserted.AddRange(typesGrouped);
            }

            return new TypesAssertionResult(typesFiltered, typesAsserted.Distinct());
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
