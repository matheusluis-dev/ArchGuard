namespace ArchGuard.Core.Contexts
{
    using System;
    using System.Collections.Generic;

    public sealed class AssertionContext<TMember> : ContextEngine<TMember>
    {
        private readonly ContextEngine<TMember> _filterContext;

        public AssertionContext(ContextEngine<TMember> filterContext)
        {
            _filterContext = filterContext;
        }

        protected override IEnumerable<TMember> ElementsToFilter(StringComparison comparison)
        {
            return _filterContext.GetElements(comparison);
        }

        public AssertionResult<TMember> GetResult(StringComparison comparison)
        {
            return new AssertionResult<TMember>(ElementsToFilter(comparison), GetElements(comparison));
        }
    }
}
