namespace ArchGuard.Library
{
    using System;
    using System.Linq;
    using ArchGuard.Library.Extensions.Type;
    using ArchGuard.Library.Helpers;

    public sealed class TypeSpec
    {
        public AssemblySpec AssemblySpecification { get; }
        public System.Type ReflectionType { get; }

        public string Name => ReflectionType.GetNameClean();
        public string FullName => ReflectionType.GetFullNameClean();

        public bool IsClass => ReflectionType.IsClass && !IsRecord;

        public bool IsInternal
        {
            get
            {
                // https://stackoverflow.com/questions/4971213/how-to-use-reflection-to-determine-if-a-class-is-internal
                var isInternal = ReflectionType.IsNotPublic;

                isInternal = isInternal && !IsFileScoped;

                isInternal =
                    isInternal || (ReflectionType.IsNested && ReflectionType.IsNestedAssembly);

                return isInternal;
            }
        }

        public bool IsRecord =>
            RecordsHelper
                .GetRecords(AssemblySpecification)
                .Contains(FullName, StringComparer.Ordinal);

        public bool IsFileScoped =>
            !ReflectionType.FullName.Equals(FullName, StringComparison.Ordinal)
            && FileAccessModifierHelper
                .GetFileScopedTypes(AssemblySpecification)
                .Contains(FullName, StringComparer.Ordinal);

        public bool IsPartial =>
            PartialHelper
                .GetPartialTypes(AssemblySpecification)
                .Contains(FullName, StringComparer.Ordinal);

        public TypeSpec(AssemblySpec assemblySpecification, System.Type type)
        {
            AssemblySpecification = assemblySpecification;
            ReflectionType = type;
        }

        //public override bool Equals(object obj)
        //{
        //    if (!(obj is TypeSpec typeSpec))
        //    {
        //        return false;
        //    }

        //    return ReflectionType.Equals(typeSpec.ReflectionType);
        //}

        //public override int GetHashCode()
        //{
        //    return ReflectionType.GetHashCode();
        //}
    }
}
