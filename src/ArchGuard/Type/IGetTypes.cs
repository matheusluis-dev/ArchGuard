namespace ArchGuard
{
    using System;
    using System.Collections.Generic;

    public interface IGetTypes
    {
        IEnumerable<TypeDefinition> GetTypes();
        IEnumerable<TypeDefinition> GetTypes(StringComparison comparison);
    }
}
