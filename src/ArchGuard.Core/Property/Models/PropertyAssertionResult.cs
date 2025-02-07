namespace ArchGuard.Core.Property.Models
{
    using System.Collections.Generic;

    public sealed class PropertyAssertionResult
    {
        public bool IsSuccessful => !NonCompliantProperties.Any();
        public IEnumerable<PropertyDefinition> PropertiesFiltered { get; }
        public IEnumerable<PropertyDefinition> CompliantProperties { get; }
        public IEnumerable<PropertyDefinition> NonCompliantProperties =>
            PropertiesFiltered.Except(CompliantProperties);

        internal PropertyAssertionResult(
            IEnumerable<PropertyDefinition> propertiesFiltered,
            IEnumerable<PropertyDefinition> propertiesAsserted
        )
        {
            PropertiesFiltered = propertiesFiltered;
            CompliantProperties = propertiesAsserted;
        }
    }
}
