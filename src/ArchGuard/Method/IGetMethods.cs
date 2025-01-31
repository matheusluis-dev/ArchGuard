namespace ArchGuard
{
    using System;
    using System.Collections.Generic;

    public interface IGetMethods
    {
        IEnumerable<MethodDefinition> GetMethods();
        IEnumerable<MethodDefinition> GetMethods(StringComparison comparison);
    }
}
