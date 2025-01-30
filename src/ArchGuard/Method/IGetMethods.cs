namespace ArchGuard
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Kernel.Models;

    public interface IGetMethods
    {
        IEnumerable<MethodDefinition> GetMethods();
        IEnumerable<MethodDefinition> GetMethods(StringComparison comparison);
    }
}
