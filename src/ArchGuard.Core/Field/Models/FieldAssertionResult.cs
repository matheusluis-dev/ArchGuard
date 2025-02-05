namespace ArchGuard.Core.Field.Models
{
    using System.Collections.Generic;

    public sealed class FieldAssertionResult
    {
        public bool IsSuccessful => !NonCompliantFields.Any();
        public IEnumerable<FieldDefinition> FieldsFiltered { get; }
        public IEnumerable<FieldDefinition> CompliantFields { get; }
        public IEnumerable<FieldDefinition> NonCompliantFields =>
            FieldsFiltered.Except(CompliantFields);

        internal FieldAssertionResult(
            IEnumerable<FieldDefinition> fieldsFiltered,
            IEnumerable<FieldDefinition> fieldsAsserted
        )
        {
            FieldsFiltered = fieldsFiltered;
            CompliantFields = fieldsAsserted;
        }
    }
}
