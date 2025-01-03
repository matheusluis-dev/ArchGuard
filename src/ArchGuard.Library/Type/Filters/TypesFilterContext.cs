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

        // TODO: Refactor to use enums
        private bool AndOperator { get; set; } = true;

        // TODO: Refactor to use enums
        private bool OrOperator { get; set; }

        private List<IEnumerable<Type>> GroupedTypes { get; } = new List<IEnumerable<Type>>();

        // TODO: Refactor to use enums
        public void And()
        {
            AndOperator = true;
            OrOperator = false;
        }

        // TODO: Refactor to use enums
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
