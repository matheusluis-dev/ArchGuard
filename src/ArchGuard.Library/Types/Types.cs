namespace ArchGuard.Library.Types
{
    using System;
    using System.Reflection;
    using ArchGuard.Library.Types.Filters;
    using ArchGuard.Library.Types.Filters.Common.Interfaces;

    public sealed class Types
    {
        private Types() { }

        public static ITypesFilterStart FromAssembly(Assembly assembly)
        {
            if (assembly is null)
                throw new ArgumentNullException(nameof(assembly));

            var types = assembly.GetTypes();
            var context = new TypesFilterContext(types);

            return TypesFilter.Create(context);
        }
    }
}
