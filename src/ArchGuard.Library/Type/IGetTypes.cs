namespace ArchGuard.Library.Type
{
    using System;
    using System.Collections.Generic;

    public interface IGetTypes
    {
        IEnumerable<TypeSpecRoslyn> GetTypes();
        IEnumerable<TypeSpecRoslyn> GetTypes(StringComparison comparison);
    }
}
