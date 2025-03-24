//namespace ArchGuard.Filters.Base;
//public class Assertion<TRule, TContext> : ISequence<TRule, TContext>
//    where TRule : RuleBase<TContext>
//    where TContext : class
//{
//    private readonly AddRuleCallback<TRule, TContext> _addRule;
//    private readonly AddContextOrCallback _contextOr;

//    internal Assertion(AddRuleCallback<TRule, TContext> addRule, AddContextOrCallback contextOr)
//    {
//        _addRule = addRule;
//        _contextOr = contextOr;
//    }

//    public TRule And => _addRule.Invoke();

//    public TRule Or
//    {
//        get
//        {
//            _contextOr.Invoke();
//            return _addRule.Invoke();
//        }
//    }
//}
