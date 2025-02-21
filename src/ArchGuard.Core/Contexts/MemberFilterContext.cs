namespace ArchGuard.Core.Contexts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class MemberFilterContext<TMember> : ContextEngine<TMember>
    {
        private readonly TypeFilterContext _typeFilterContext;

        public MemberFilterContext(TypeFilterContext typeFilterContext)
        {
            _typeFilterContext = typeFilterContext;
        }

        protected override IEnumerable<TMember> ElementsToFilter(StringComparison comparison)
        {
            return _typeFilterContext.GetElements(comparison).SelectMany(type => type.GetMembers<TMember>());
        }
    }
}
