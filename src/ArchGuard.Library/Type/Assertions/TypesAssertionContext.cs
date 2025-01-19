namespace ArchGuard.Library.Type.Assertions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Library.Type.Filters;
    using Microsoft.CodeAnalysis;

    public sealed class TypesAssertionContext
    {
        private readonly List<
            List<Func<TypeDefinition, StringComparison, bool>>
        > _groupedAssertionPredicates = new();

        private readonly TypesFilterContext _filterContext;

        public TypesAssertionContext(TypesFilterContext filterContext)
        {
            _filterContext = filterContext;
        }

        private void CreateGroupedPredicate()
        {
            _groupedAssertionPredicates.Add(
                new List<Func<TypeDefinition, StringComparison, bool>>()
            );
        }

        public void AddPredicate(Func<TypeDefinition, StringComparison, bool> predicate)
        {
            if (_groupedAssertionPredicates.Count == 0)
                CreateGroupedPredicate();

            _groupedAssertionPredicates[^1].Add(predicate);
        }

        public void Or()
        {
            CreateGroupedPredicate();
        }

        private IEnumerable<TypeDefinition> ExecuteAssertions(
            IEnumerable<TypeDefinition> typesParam,
            StringComparison comparison
        )
        {
            if (_groupedAssertionPredicates.Count == 0)
                return typesParam;

            var types = new List<TypeDefinition>();

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
            var typesToAssert = _filterContext.GetTypes(comparison);
            var typesAsserted = ExecuteAssertions(typesToAssert, comparison);

            return new TypesAssertionResult(typesToAssert, typesAsserted);
        }
    }
}
