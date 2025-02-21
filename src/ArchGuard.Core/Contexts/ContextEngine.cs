namespace ArchGuard.Core.Contexts
{
    public abstract class ContextEngine<TMember>
    {
        private readonly List<List<Func<TMember, StringComparison, bool>>> _groupedPredicates = new();

        protected abstract IEnumerable<TMember> ElementsToFilter(StringComparison comparison);

        private void CreateGroupedPredicate()
        {
            _groupedPredicates.Add(new());
        }

        public void AddPredicate(Func<TMember, StringComparison, bool> predicate)
        {
            if (_groupedPredicates.Count == 0)
                CreateGroupedPredicate();

            _groupedPredicates[^1].Add(predicate);
        }

        public void Or()
        {
            CreateGroupedPredicate();
        }

        public IEnumerable<TMember> GetElements(StringComparison comparison)
        {
            if (_groupedPredicates.Count == 0)
                return ElementsToFilter(comparison);

            var elements = new HashSet<TMember>();
            foreach (var group in _groupedPredicates)
            {
                var typesGrouped = ElementsToFilter(comparison).ToList().AsEnumerable();

                foreach (var predicate in group)
                    typesGrouped = typesGrouped.Where(type => predicate(type, comparison));

                elements.UnionWith(typesGrouped);
            }

            return elements;
        }
    }
}
