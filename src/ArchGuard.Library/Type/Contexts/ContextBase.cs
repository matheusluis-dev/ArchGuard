namespace ArchGuard.Library.Type.Contexts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal abstract class ContextBase<T>
        where T : class
    {
        private readonly List<List<Func<T, StringComparison, bool>>> _groupedPredicates = new();

        private readonly IEnumerable<T>? _elements;
        private readonly ContextBase<T>? _anotherContext;

        private delegate IEnumerable<T> Elements(StringComparison comparison);
        private readonly Elements _getElements;

        protected ContextBase(IEnumerable<T> elements)
        {
            ArgumentNullException.ThrowIfNull(elements);

            _elements = elements;
            _getElements = GetElementsFromEnumerable;
        }

        protected ContextBase(ContextBase<T> anotherContext)
        {
            ArgumentNullException.ThrowIfNull(anotherContext);

            _anotherContext = anotherContext;
            _getElements = GetElementsFromAnotherContext;
        }

        private IEnumerable<T> GetElementsFromEnumerable(StringComparison comparison)
        {
            ArgumentNullException.ThrowIfNull(_elements);

            return _elements;
        }

        private IEnumerable<T> GetElementsFromAnotherContext(StringComparison comparison)
        {
            ArgumentNullException.ThrowIfNull(_anotherContext);

            return _anotherContext.GetElements(comparison);
        }

        private void CreateGroupedPredicate()
        {
            _groupedPredicates.Add(new());
        }

        protected internal void AddPredicate(Func<T, StringComparison, bool> predicate)
        {
            if (_groupedPredicates.Count == 0)
                CreateGroupedPredicate();

            _groupedPredicates[_groupedPredicates.Count - 1].Add(predicate);
        }

        protected internal void Or()
        {
            CreateGroupedPredicate();
        }

        protected IEnumerable<T> GetElementsWithoutFilter()
        {
            return GetElementsWithoutFilter(StringComparison.CurrentCulture);
        }

        protected IEnumerable<T> GetElementsWithoutFilter(StringComparison comparison)
        {
            return _getElements(comparison);
        }

        protected IEnumerable<T> GetElements()
        {
            return GetElements(Default.StringComparison);
        }

        protected IEnumerable<T> GetElements(StringComparison comparison)
        {
            if (_groupedPredicates.Count == 0)
                return _getElements(comparison);

            var elements = new HashSet<T>();
            foreach (var group in _groupedPredicates)
            {
                var typesGrouped = _getElements(comparison).ToList().AsEnumerable();

                foreach (var predicate in group)
                    typesGrouped = typesGrouped.Where(type => predicate(type, comparison));

                elements.UnionWith(typesGrouped);
            }

            return elements;
        }
    }
}
