namespace ArchGuard.Library.Type.Assertions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class TypesAssertionContext
    {
        private readonly IEnumerable<Type> _types;
        private readonly IEnumerable<IEnumerable<Func<Type, StringComparison, bool>>> _filters;
        private readonly List<
            List<Func<Type, StringComparison, bool>>
        > _groupedAssertionPredicates = new List<List<Func<Type, StringComparison, bool>>>();

        public TypesAssertionContext(
            IEnumerable<Type> types,
            IEnumerable<IEnumerable<Func<Type, StringComparison, bool>>> filters
        )
        {
            _types = types;
            _filters = filters;
        }

        private void CreateGroupedPredicate()
        {
            _groupedAssertionPredicates.Add(new List<Func<Type, StringComparison, bool>>());
        }

        public void AddPredicate(Func<Type, StringComparison, bool> predicate)
        {
            if (_groupedAssertionPredicates.Count == 0)
                CreateGroupedPredicate();

            _groupedAssertionPredicates[_groupedAssertionPredicates.Count - 1].Add(predicate);
        }

        public void Or()
        {
            CreateGroupedPredicate();
        }

        private IEnumerable<Type> ExecuteFilters(StringComparison comparison)
        {
            if (!_filters.Any())
                return _types;

            var types = new List<Type>();

            foreach (var group in _filters)
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

        private IEnumerable<Type> ExecuteAssertions(
            IEnumerable<Type> typesParam,
            StringComparison comparison
        )
        {
            if (_groupedAssertionPredicates.Count == 0)
                return typesParam;

            var types = new List<Type>();

            foreach (var group in _groupedAssertionPredicates)
            {
                var typesGrouped = typesParam;
                foreach (var predicate in group)
                {
                    typesGrouped = typesGrouped.Where(type => predicate(type, comparison));
                }

                types.AddRange(typesGrouped);
            }

            return types.Distinct();
        }

        public TypesAssertionResult GetResult()
        {
            return GetResult(StringComparison.CurrentCulture);
        }

        public TypesAssertionResult GetResult(StringComparison comparison)
        {
            var typesToAssert = ExecuteFilters(comparison);
            var typesAsserted = ExecuteAssertions(typesToAssert, comparison);

            return new TypesAssertionResult(typesToAssert, typesAsserted);
        }
    }
}
