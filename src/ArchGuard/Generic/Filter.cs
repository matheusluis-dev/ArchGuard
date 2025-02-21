namespace ArchGuard.Generic
{
    using ArchGuard.Core.Contexts;
    using ArchGuard.Core.Type.Models;

    internal class Filter<TRule, TContext> : IFilterEntryPoint<TRule>, IFilterSequence<TRule>
        where TRule : class, IRule
        where TContext : class
    {
        private readonly TRule _rule;
        private readonly ContextEngine<TContext> _context;

        public Filter(TRule rule, ContextEngine<TContext> context)
        {
            _rule = rule;
            _context = context;
        }

        public TRule That
        {
            get
            {
                _rule.Callback = () => this;
                return _rule;
            }
        }

        public TRule And => _rule;

        public TRule Or
        {
            get
            {
                _context.Or();
                return _rule;
            }
        }

        public void Aaa()
        {
            var entry =
                (IFilterEntryPoint<FilterTypeRule<TContext>>)
                    new Filter<FilterTypeRule<TContext>, TypeDefinition>(
                        new FilterTypeRule<TContext>(),
                        new TypeFilterContext([])
                    );

            entry.That.Whatever().Or.Whatever().And.Whatever();
        }
    }
}
