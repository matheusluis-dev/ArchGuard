namespace ArchGuard.Library.Type.Assertions
{
    using System;
    using ArchGuard.Type.Assertions.Models;

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
