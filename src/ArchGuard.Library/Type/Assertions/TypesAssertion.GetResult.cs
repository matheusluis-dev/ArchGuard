namespace ArchGuard.Library.Type.Assertions
{
    using System;
    using ArchGuard.Library.Type.Assertions;

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
