namespace ArchGuard.Library.Type.Assertions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class TypesAssertionContext
    {
        private readonly IEnumerable<Type> _types;
        private readonly IEnumerable<IEnumerable<Func<Type, bool>>> _filters;
        private readonly List<List<Func<Type, bool>>> _groupedAssertionPredicates =
            new List<List<Func<Type, bool>>>();

        public TypesAssertionContext(
            IEnumerable<Type> types,
            IEnumerable<IEnumerable<Func<Type, bool>>> filters
        )
        {
            _types = types;
            _filters = filters;
        }

        private void CreateGroupedPredicate()
        {
            _groupedAssertionPredicates.Add(new List<Func<Type, bool>>());
        }

        public void AddPredicate(Func<Type, bool> predicate)
        {
            if (_groupedAssertionPredicates.Count == 0)
                CreateGroupedPredicate();

            _groupedAssertionPredicates[_groupedAssertionPredicates.Count - 1].Add(predicate);
        }

        public void Or()
        {
            CreateGroupedPredicate();
        }

        private IEnumerable<Type> ExecuteFilters()
        {
            if (!_filters.Any())
                return _types;

            var types = new List<Type>();

            foreach (var group in _filters)
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

        private IEnumerable<Type> ExecuteAssertions(IEnumerable<Type> typesParam)
        {
            if (_groupedAssertionPredicates.Count == 0)
                return typesParam;

            var types = new List<Type>();

            foreach (var group in _groupedAssertionPredicates)
            {
                var typesGrouped = typesParam;
                foreach (var predicate in group)
                {
                    typesGrouped = typesGrouped.Where(predicate);
                }

                types.AddRange(typesGrouped);
            }

            return types.Distinct();
        }

        public TypesAssertionResult GetResult()
        {
            var typesToAssert = ExecuteFilters();
            var typesAsserted = ExecuteAssertions(typesToAssert);

            return new TypesAssertionResult(typesToAssert, typesAsserted);
        }
    }
}
