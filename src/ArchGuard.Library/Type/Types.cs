namespace ArchGuard.Library.Type
{
    using System;
    using System.Reflection;
    using ArchGuard.Library.Type.Filters;

    public sealed class Types
    {
        private Types() { }

        public static ITypesFilterStart FromAssembly(Assembly assembly)
        {
            if (assembly is null)
                throw new ArgumentNullException(nameof(assembly));

            var types = TypesLoader.LoadFromAssembly(assembly);

            var context = new TypesFilterContext(types);

            return TypesFilter.Create(context);
        }
    }
}
