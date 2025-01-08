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

        public bool IsClass => ReflectionType.IsClass
#if NET5_0_OR_GREATER
            && !IsRecord
#endif
        ;

        public bool IsInternal
        {
            get
            {
                // https://stackoverflow.com/questions/4971213/how-to-use-reflection-to-determine-if-a-class-is-internal
                var isInternal = ReflectionType.IsNotPublic;
#if NET7_0_OR_GREATER
                isInternal = isInternal && !IsFileScoped;
#endif
                isInternal =
                    isInternal || (ReflectionType.IsNested && ReflectionType.IsNestedAssembly);

                return isInternal;
            }
        }

#if NET5_0_OR_GREATER
        public bool IsRecord =>
            RecordsHelper
                .GetRecords(AssemblySpecification)
                .Contains(FullName, StringComparer.Ordinal);
#endif

#if NET7_0_OR_GREATER
        public bool IsFileScoped =>
            !ReflectionType.FullName.Equals(FullName, StringComparison.Ordinal)
            && FileAccessModifierHelper
                .GetFileScopedTypes(AssemblySpecification)
                .Contains(FullName, StringComparer.Ordinal);
#endif

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
