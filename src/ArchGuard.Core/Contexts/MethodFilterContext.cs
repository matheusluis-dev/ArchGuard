namespace ArchGuard.Contexts
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Core.Models;

    public sealed class MethodFilterContext
    {
        private readonly List<
            List<Func<MethodDefinition, StringComparison, bool>>
        > _groupedPredicates = new();

        private readonly TypeFilterContext _typeFilterContext;

        public MethodFilterContext(TypeFilterContext typeFilterContext)
        {
            _typeFilterContext = typeFilterContext;
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

        public IEnumerable<MethodDefinition> GetMethods()
        {
            return GetMethods(Default.StringComparison);
        }

        public IEnumerable<MethodDefinition> GetMethods(StringComparison comparison)
        {
            var methods = _typeFilterContext
                .GetTypes(comparison)
                .SelectMany(type => type.GetMethods());

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
    }
}
