namespace ArchGuard
{
    using System;

    public sealed partial class TypeDefinitionAssertion
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
