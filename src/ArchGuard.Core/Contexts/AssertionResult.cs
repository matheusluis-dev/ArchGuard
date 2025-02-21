namespace ArchGuard.Core.Contexts
{
    using System.Collections.Generic;
    using System.Linq;

    public sealed class AssertionResult<TMember>
    {
        public bool IsSuccessful => !NonCompliant.Any();
        public IEnumerable<TMember> Found { get; }
        public IEnumerable<TMember> Compliant { get; }
        public IEnumerable<TMember> NonCompliant => Found.Except(Compliant);

        internal AssertionResult(IEnumerable<TMember> propertiesFiltered, IEnumerable<TMember> propertiesAsserted)
        {
            Found = propertiesFiltered;
            Compliant = propertiesAsserted;
        }
    }
}
