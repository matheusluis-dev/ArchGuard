namespace ArchGuard.Core.Method.Contexts
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Core.Method.Models;

    public sealed class MethodAssertionContext
    {
        private readonly List<
            List<Func<MethodDefinition, StringComparison, bool>>
        > _groupedPredicates = new();

        private readonly MethodFilterContext _methodFilterContext;

        public MethodAssertionContext(MethodFilterContext methodFilterContext)
        {
            _methodFilterContext = methodFilterContext;
        }

        private void CreateGroupedPredicate()
        {
            _groupedPredicates.Add(new());
        }

        public void AddPredicate(Func<MethodDefinition, StringComparison, bool> predicate)
        {
            if (_groupedPredicates.Count == 0)
                CreateGroupedPredicate();

            _groupedPredicates[^1].Add(predicate);
        }

        public void Or()
        {
            CreateGroupedPredicate();
        }

        private IEnumerable<MethodDefinition> GetMethods(StringComparison comparison)
        {
            var methods = _methodFilterContext.GetMethods(comparison);

            if (_groupedPredicates.Count == 0)
                return methods;

            var elements = new HashSet<MethodDefinition>();
            foreach (var group in _groupedPredicates)
            {
                var elementsGrouped = methods.ToList().AsEnumerable();

                foreach (var predicate in group)
                    elementsGrouped = elementsGrouped.Where(type => predicate(type, comparison));

                elements.UnionWith(elementsGrouped);
            }

            return elements;
        }

        public MethodAssertionResult GetResult()
        {
            return GetResult(Default.StringComparison);
        }

        public MethodAssertionResult GetResult(StringComparison comparison)
        {
            var methodsFiltered = _methodFilterContext.GetMethods(comparison);
            var methodsAsserted = GetMethods(comparison);

            return new MethodAssertionResult(methodsFiltered, methodsAsserted);
        }
    }
}
