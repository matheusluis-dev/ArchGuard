namespace ArchGuard
{
    using System;

    public sealed partial class TypeAssertion
    {
        public TypeAssertionResult GetResult()
        {
            return _context.GetResult();
        }

        public TypeAssertionResult GetResult(StringComparison comparison)
        {
            return _context.GetResult(comparison);
        }
    }
}
