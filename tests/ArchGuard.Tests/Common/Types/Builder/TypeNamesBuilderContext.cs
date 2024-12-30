namespace ArchGuard.Tests.Common.Types.Builder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal sealed class TypeNamesBuilderContext
    {
        private readonly FieldInfo[] _typesWithoutFilter;

        public FieldInfo[] Types { get; private set; }

        private bool AndOperator { get; set; } = true;
        private bool OrOperator { get; set; }

        private List<FieldInfo[]> GroupedTypes { get; set; } = new List<FieldInfo[]>();

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

            GroupedTypes.Add(new List<FieldInfo>(Types).ToArray());
        }

        public TypeNamesBuilderContext(FieldInfo[] types)
        {
            Types = new List<FieldInfo>(types).ToArray();
            _typesWithoutFilter = new List<FieldInfo>(types).ToArray();
        }

        public void ApplyFilter(Func<FieldInfo, bool> filter)
        {
            if (OrOperator)
            {
                var orTypes = _typesWithoutFilter.Where(filter);
                Types = Types.Union(orTypes).ToArray();

                return;
            }

            if (AndOperator)
                Types = Types.Where(filter).ToArray();

            foreach (var group in GroupedTypes)
                Types = Types.Union(group).ToArray();
        }
    }
}
