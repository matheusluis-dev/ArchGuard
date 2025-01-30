namespace ArchGuard
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Kernel.Models;

    public interface IGetTypes
    {
        IEnumerable<TypeDefinition> GetTypes();
        IEnumerable<TypeDefinition> GetTypes(StringComparison comparison);
    }
}
