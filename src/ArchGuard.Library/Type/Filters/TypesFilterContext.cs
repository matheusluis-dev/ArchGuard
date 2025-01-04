namespace ArchGuard.Library.Type.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Library.Extensions;
    using ArchGuard.Library.Type;

    public sealed class TypesFilterContext
    {
        private readonly IEnumerable<Type> _typesWithoutFilter;

        public IEnumerable<Type> Types { get; private set; }

        private LogicalOperator LogicalOperator { get; set; } = LogicalOperator.And;

        private List<IEnumerable<Type>> GroupedTypes { get; } = new List<IEnumerable<Type>>();

        public void And()
        {
            LogicalOperator = LogicalOperator.And;
        }

        public void Or()
        {
            LogicalOperator = LogicalOperator.Or;
            GroupedTypes.Add(Types.Copy());
        }

        public TypesFilterContext(IEnumerable<Type> types)
        {
            Types = types.Copy();
            _typesWithoutFilter = types.Copy();
        }

        public void ApplyFilter(Func<Type, bool> filter)
        {
            if (LogicalOperator == LogicalOperator.Or)
            {
                var orTypes = _typesWithoutFilter.Where(filter);
                Types = Types.Union(orTypes);
            }
            else
            {
                Types = Types.Where(filter);
            }

            GroupedTypes.ForEach(group => Types = Types.Union(group));
        }
    }
}
