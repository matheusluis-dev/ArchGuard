namespace ArchGuard
{
    using System;
    using System.Collections.Generic;
    using ArchGuard.Core.Method.Models;

    public interface IGetMethods
    {
        IEnumerable<MethodDefinition> GetMethods();
        IEnumerable<MethodDefinition> GetMethods(StringComparison comparison);
    }
}
