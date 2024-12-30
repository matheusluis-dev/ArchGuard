namespace ArchGuard.Library.Types
{
    using System;
    using System.Linq;
    using System.Reflection;
    using ArchGuard.Library.Types.Filters;
    using ArchGuard.Library.Types.Filters.Common.Interfaces;

    public sealed class Types
    {
        private Types() { }

        public static ITypesFilterStart FromAssembly(
            Assembly assembly,
            bool ignoreSystem = true,
            bool ignoreMicrosoft = true
        )
        {
            if (assembly is null)
                throw new ArgumentNullException(nameof(assembly));

            var types = assembly.GetTypes();

            if (ignoreSystem)
            {
                types = types
                    .Where(t => !t.Namespace.StartsWith("System", StringComparison.Ordinal))
                    .ToArray();
            }

            if (ignoreMicrosoft)
            {
                types = types
                    .Where(t => !t.Namespace.StartsWith("Microsoft", StringComparison.Ordinal))
                    .ToArray();
            }

            var context = new TypesFilterContext(types);

            return TypesFilter.Create(context);
        }
    }
}
