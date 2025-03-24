namespace ArchGuard.__filters.Engines;

using ArchGuard.Core.Contexts;
using ArchGuard.Filters.Base;

public delegate TAssertionRules Should<TAssertionRules, TContext>()
    where TAssertionRules : RuleBase<TContext>
    where TContext : class;

public sealed class FilterEngine<TFilterRules, TAssertionRules, TContext>
    where TFilterRules : RuleBase<TContext>
    where TContext : class
    where TAssertionRules : RuleBase<TContext>
{
    private readonly FilterMediator<TFilterRules, TContext> _filterMediator;
    private readonly FilterMediator<TAssertionRules, TContext> _assertionMediator;

    private FilterEngine(
        TFilterRules filterRules,
        ContextEngine<TContext> filterContext,
        TAssertionRules assertionRules,
        AssertionContext<TContext> assertionContext
    )
    {
        _filterMediator = new FilterMediator<TFilterRules, TContext>(filterRules, filterContext);
        _assertionMediator = new FilterMediator<TAssertionRules, TContext>(assertionRules, assertionContext);

        _filterMediator.ShouldCallback = () => _assertionMediator.Start().That;
    }

    internal static IFilterEntryPoint<TFilterRules, TContext> Start(
        TFilterRules filterRules,
        ContextEngine<TContext> filterContext,
        TAssertionRules assertionRules,
        AssertionContext<TContext> assertionContext
    )
    {
        var filterEngine = new FilterEngine<TFilterRules, TAssertionRules, TContext>(
            filterRules,
            filterContext,
            assertionRules,
            assertionContext
        );

        return filterEngine._filterMediator.Start()!;
    }
}
