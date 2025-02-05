namespace ArchGuard
{
    using System.Collections.Generic;
    using ArchGuard.Core.Field.Models;

    public interface IGetFields
    {
        IEnumerable<FieldDefinition> GetFields();
        IEnumerable<FieldDefinition> GetFields(StringComparison comparison);
    }
}
