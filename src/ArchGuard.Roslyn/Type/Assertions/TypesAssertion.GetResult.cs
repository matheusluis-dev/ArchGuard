namespace ArchGuard.Roslyn.Type.Assertions
{
    using System;

    public sealed partial class TypesAssertion
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
