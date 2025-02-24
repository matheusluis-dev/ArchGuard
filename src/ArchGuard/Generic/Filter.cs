namespace ArchGuard.Generic;

using System.Linq;
using ArchGuard.Core.Contexts;
using ArchGuard.Core.Type.Models;

public class Filter<TRule, TContext> : IFilterEntryPoint<TRule>, IFilterSequence<TRule, TContext>
    where TRule : class, IRule<TContext>
    where TContext : class
{
    private readonly AddRuleCallback<TRule, TContext> _addRule;
    private readonly AddContextOrCallback _contextOr;

    internal Filter(AddRuleCallback<TRule, TContext> addRule, AddContextOrCallback contextOr)
    {
        _addRule = addRule;
        _contextOr = contextOr;
    }

    public TRule That => _addRule.Invoke();

    public TRule And => _addRule.Invoke();

    public TRule Or
    {
        get
        {
            _contextOr.Invoke();
            return _addRule.Invoke();
        }
    }

    public void Aaa()
    {
        var entry = new FilterEngine<FilterTypeRule, TypeDefinition>(
            new FilterTypeRule(),
            new TypeFilterContext(Enumerable.Empty<TypeDefinition>())
        ).Start();

        entry.That.AreClasses().And.AreClasses();
    }
}
