namespace ArchGuard.Type.Common
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Type;

    public interface IGetTypes
    {
        IEnumerable<TypeDefinition> GetTypes();
        IEnumerable<TypeDefinition> GetTypes(StringComparison comparison);
    }
}
