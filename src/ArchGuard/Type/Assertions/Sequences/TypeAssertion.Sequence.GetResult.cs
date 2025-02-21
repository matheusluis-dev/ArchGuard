namespace ArchGuard
{
    using System;
    using ArchGuard.Core.Contexts;
    using ArchGuard.Core.Type.Models;

    public sealed partial class TypeAssertion
    {
        public AssertionResult<TypeDefinition> GetResult()
        {
            return GetResult(Default.StringComparison);
        }

        public AssertionResult<TypeDefinition> GetResult(StringComparison comparison)
        {
            return _context.GetResult(comparison);
        }
    }
}
