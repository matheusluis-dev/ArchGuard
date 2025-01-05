namespace ArchGuard.Library.Type.Assertions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Library.Extensions;
    using ArchGuard.Library.Type;

    public sealed class TypesAssertionContext
    {
        private readonly IEnumerable<Type> _typesFiltered;

        private readonly List<Type> _typesAsserted;
        private readonly List<IEnumerable<Type>> _groupedTypes;

        public TypesAssertionContext(IEnumerable<Type> typesFiltered)
        {
            _typesFiltered = typesFiltered;

            _typesAsserted = new List<Type>();
            _groupedTypes = new List<IEnumerable<Type>>();
        }

        private LogicalOperator LogicalOperator { get; set; } = LogicalOperator.And;

        public void And()
        {
            LogicalOperator = LogicalOperator.And;
        }

        public void Or()
        {
            LogicalOperator = LogicalOperator.Or;
            _groupedTypes.Add(_typesFiltered.Copy());
        }

        public void ApplyAssertion(Func<Type, bool> filter)
        {
            if (LogicalOperator == LogicalOperator.Or)
            {
                var orTypes = _typesFiltered.Where(filter);
                _typesAsserted.AddRange(orTypes.Except(_typesAsserted));
            }
            else
            {
                _typesAsserted.AddRange(_typesFiltered.Where(filter).Except(_typesAsserted));
            }

            _groupedTypes.ForEach(group => _typesAsserted.AddRange(group.Except(_typesAsserted)));
        }

        public TypesAssertionResult ToResult()
        {
            return new TypesAssertionResult(_typesFiltered, _typesAsserted);
        }
    }
}
