namespace ArchGuard.Library.Type
{
    using System;
    using System.Collections.Generic;

    public interface IGetTypes
    {
        IEnumerable<TypeSpec> GetTypes();
        IEnumerable<TypeSpec> GetTypes(StringComparison comparison);
    }
}
