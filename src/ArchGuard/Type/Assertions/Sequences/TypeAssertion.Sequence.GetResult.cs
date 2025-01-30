namespace ArchGuard
{
    using System;

    public sealed partial class TypeAssertion
    {
        public TypesAssertionResult GetResult()
        {
            return _context.GetResult();
        }

        public TypesAssertionResult GetResult(StringComparison comparison)
        {
            return _context.GetResult(comparison);
        }
    }
}
