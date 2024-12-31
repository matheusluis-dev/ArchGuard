namespace ArchGuard.Library.Type.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Library.Extensions;

    public sealed class TypesFilterContext
    {
        private readonly IEnumerable<Type> _typesWithoutFilter;

        public IEnumerable<Type> Types { get; private set; }

        private bool AndOperator { get; set; } = true;
        private bool OrOperator { get; set; }

        private List<IEnumerable<Type>> GroupedTypes { get; set; } = new List<IEnumerable<Type>>();

        public void And()
        {
            AndOperator = true;
            OrOperator = false;
        }

        public void Or()
        {
            AndOperator = false;
            OrOperator = true;

            GroupTypes();
        }

        private void GroupTypes()
        {
            if (!OrOperator)
                throw new InvalidOperationException();

            GroupedTypes.Add(Types.Copy());
        }

        public TypesFilterContext(IEnumerable<Type> types)
        {
            Types = types.Copy();
            _typesWithoutFilter = types.Copy();
        }

        public void ApplyFilter(Func<Type, bool> filter)
        {
            if (OrOperator)
            {
                var orTypes = _typesWithoutFilter.Where(filter);
                Types = Types.Union(orTypes);

                return;
            }

            if (AndOperator)
                Types = Types.Where(filter);

            GroupedTypes.ForEach(group => Types = Types.Union(group));
        }
    }
}
