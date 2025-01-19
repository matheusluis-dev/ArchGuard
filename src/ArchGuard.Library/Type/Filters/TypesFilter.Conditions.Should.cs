namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Assertions;

    public sealed partial class TypesFilter
    {
        public ITypesAssertionCondition Should => _callback.Invoke();
    }
}
