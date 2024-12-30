namespace ArchGuard.Tests.Common.Types.Builder
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Linq;

    internal sealed class TypeNamesFromMockedAssembly
        : ITypeNamesBuilderCondition,
            ITypeNamesBuilderPostCondition
    {
        private readonly TypeNamesBuilderContext _context;

        private TypeNamesFromMockedAssembly(TypeNamesBuilderContext context)
        {
            _context = context;
        }

        private static TypeNamesFromMockedAssembly CreateBuilderWithContext()
        {
            var context = new TypeNamesBuilderContext(
                typeof(TypeNamesRefactorStatic).GetFields(
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static
                )
            );

            return new TypeNamesFromMockedAssembly(context);
        }

        public static ITypeNamesBuilderPostCondition All()
        {
            return CreateBuilderWithContext();
        }

        public static ITypeNamesBuilderCondition That()
        {
            return CreateBuilderWithContext();
        }

        public static ITypeNamesBuilderPostCondition That(
            Func<ITypeNamesBuilderCondition, ITypeNamesBuilderPostCondition> filter
        )
        {
            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            var builder = CreateBuilderWithContext();

            return filter(builder);
        }

        public ITypeNamesBuilderCondition And()
        {
            _context.And();
            return this;
        }

        public ITypeNamesBuilderPostCondition And(
            Func<ITypeNamesBuilderCondition, ITypeNamesBuilderPostCondition> filter
        )
        {
            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            _context.And();
            filter(this);

            return this;
        }

        public ITypeNamesBuilderCondition Or()
        {
            _context.Or();
            return this;
        }

        public ITypeNamesBuilderPostCondition Or(
            Func<ITypeNamesBuilderCondition, ITypeNamesBuilderPostCondition> filter
        )
        {
            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            _context.Or();
            filter(this);

            return this;
        }

        public ITypeNamesBuilderPostCondition AreClasses()
        {
            _context.ApplyFilter(c => c.Name.IndexOf("Class", StringComparison.Ordinal) >= 0);
            return this;
        }

        public ITypeNamesBuilderPostCondition AreNotClasses()
        {
            _context.ApplyFilter(c => c.Name.IndexOf("Class", StringComparison.Ordinal) < 0);
            return this;
        }

        public ITypeNamesBuilderPostCondition AreEnums()
        {
            _context.ApplyFilter(e => e.Name.IndexOf("Enum", StringComparison.Ordinal) >= 0);
            return this;
        }

        public ITypeNamesBuilderPostCondition AreNotEnums()
        {
            _context.ApplyFilter(e => e.Name.IndexOf("Enum", StringComparison.Ordinal) < 0);
            return this;
        }

        public ITypeNamesBuilderPostCondition AreInterfaces()
        {
            _context.ApplyFilter(i => i.Name.IndexOf("Interface", StringComparison.Ordinal) >= 0);
            return this;
        }

        public ITypeNamesBuilderPostCondition AreNotInterfaces()
        {
            _context.ApplyFilter(i => i.Name.IndexOf("Interface", StringComparison.Ordinal) < 0);
            return this;
        }

        public ITypeNamesBuilderPostCondition AreRecords()
        {
            _context.ApplyFilter(i => i.Name.IndexOf("Record", StringComparison.Ordinal) >= 0);
            return this;
        }

        public ITypeNamesBuilderPostCondition AreNotRecords()
        {
            _context.ApplyFilter(i => i.Name.IndexOf("Record", StringComparison.Ordinal) < 0);
            return this;
        }

        public ITypeNamesBuilderPostCondition ArePublic()
        {
            _context.ApplyFilter(i => i.Name.IndexOf("Public", StringComparison.Ordinal) >= 0);
            return this;
        }

        public ITypeNamesBuilderPostCondition AreNotPublic()
        {
            _context.ApplyFilter(i => i.Name.IndexOf("Public", StringComparison.Ordinal) < 0);
            return this;
        }

        public ITypeNamesBuilderPostCondition AreInternal()
        {
            _context.ApplyFilter(i => i.Name.IndexOf("Internal", StringComparison.Ordinal) >= 0);
            return this;
        }

        public ITypeNamesBuilderPostCondition AreNotInternal()
        {
            _context.ApplyFilter(i => i.Name.IndexOf("Internal", StringComparison.Ordinal) < 0);
            return this;
        }

        public ITypeNamesBuilderPostCondition ArePartial()
        {
            _context.ApplyFilter(i => i.Name.IndexOf("Partial", StringComparison.Ordinal) >= 0);
            return this;
        }

        public ITypeNamesBuilderPostCondition AreNotPartial()
        {
            _context.ApplyFilter(i => i.Name.IndexOf("Partial", StringComparison.Ordinal) < 0);
            return this;
        }

        public ITypeNamesBuilderPostCondition AreSealed()
        {
            _context.ApplyFilter(i => i.Name.IndexOf("Sealed", StringComparison.Ordinal) >= 0);
            return this;
        }

        public ITypeNamesBuilderPostCondition AreNotSealed()
        {
            _context.ApplyFilter(i => i.Name.IndexOf("Sealed", StringComparison.Ordinal) < 0);
            return this;
        }

        public ITypeNamesBuilderPostCondition ResideInNamespace(string name)
        {
            _context.ApplyFilter(i =>
                ((string)i.GetRawConstantValue()).StartsWith(name, StringComparison.Ordinal)
            );
            return this;
        }

        public ITypeNamesBuilderPostCondition ResideInNamespace(
            string name,
            StringComparison comparison
        )
        {
            _context.ApplyFilter(i =>
                ((string)i.GetRawConstantValue()).StartsWith(name, comparison)
            );
            return this;
        }

        public ITypeNamesBuilderPostCondition NotResideInNamespace(string name)
        {
            _context.ApplyFilter(i =>
                !((string)i.GetRawConstantValue()).StartsWith(name, StringComparison.Ordinal)
            );
            return this;
        }

        public ITypeNamesBuilderPostCondition NotResideInNamespace(
            string name,
            StringComparison comparison
        )
        {
            _context.ApplyFilter(i =>
                !((string)i.GetRawConstantValue()).StartsWith(name, comparison)
            );
            return this;
        }

        public ITypeNamesBuilderPostCondition HaveNameStartingWith(string start)
        {
            _context.ApplyFilter(i =>
            {
                var name = (string)i.GetRawConstantValue();
                var split = name.Split('.');
                var last = split[split.Length - 1];

                return last.StartsWith(start);
            });
            return this;
        }

        public ITypeNamesBuilderPostCondition HaveNameStartingWith(
            string start,
            StringComparison comparison
        )
        {
            _context.ApplyFilter(i =>
            {
                var name = (string)i.GetRawConstantValue();
                var split = name.Split('.');
                var last = split[split.Length - 1];

                return last.StartsWith(start, comparison);
            });
            return this;
        }

        public ITypeNamesBuilderPostCondition HaveNameEndingWith(string end)
        {
            _context.ApplyFilter(i =>
            {
                var name = (string)i.GetRawConstantValue();
                var split = name.Split('.');
                var last = split[split.Length - 1];

                return last.EndsWith(end);
            });
            return this;
        }

        public ITypeNamesBuilderPostCondition HaveNameEndingWith(
            string end,
            StringComparison comparison
        )
        {
            _context.ApplyFilter(i =>
            {
                var name = (string)i.GetRawConstantValue();
                var split = name.Split('.');
                var last = split[split.Length - 1];

                return last.EndsWith(end, comparison);
            });
            return this;
        }

        public List<string> GetTypeNames()
        {
            return _context
                // TODO remove Where later
                .Types.Where(t => t.FieldType == typeof(string))
                .Select(t => t.GetRawConstantValue() as string)
                .OrderBy(v => v, StringComparer.Ordinal)
                .ToList();
        }
    }
}
