namespace ArchGuard
{
    using System.Collections.Generic;
    using ArchGuard.Core.Property.Models;

    public interface IGetProperties
    {
        IEnumerable<PropertyDefinition> GetProperties();
        IEnumerable<PropertyDefinition> GetProperties(StringComparison comparison);
    }
}
