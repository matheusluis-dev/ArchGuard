namespace ArchGuard.Library.Type
{
    using System;
    using System.Collections.Generic;

    public interface IGetTypes
    {
        IEnumerable<Type_> GetTypes();
        IEnumerable<Type_> GetTypes(StringComparison comparison);
    }
}
