namespace ArchGuard.Library.Type.Common
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Library.Type;

    public interface IGetTypes
    {
        IEnumerable<TypeDefinition> GetTypes();
        IEnumerable<TypeDefinition> GetTypes(StringComparison comparison);
    }
}
