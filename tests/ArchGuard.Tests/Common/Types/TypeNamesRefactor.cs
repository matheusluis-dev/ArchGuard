namespace ArchGuard.Tests.Common.Types
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal sealed class TypeNamesRefactor : IEnumerable<string>
    {
        private readonly List<string> _names;

        private void AddNames(IEnumerable<string> names)
        {
            foreach (var name in names)
            {
                if (name is null || _names.Contains(name))
                    continue;

                _names.Add(name);
            }
        }

        private TypeNamesRefactor() { }

        public static TypeNamesRefactor Create()
        {
            return new TypeNamesRefactor();
        }

        public TypeNamesRefactor WithPublic()
        {
            AddNames(
                typeof(TypeNamesRefactorStatic)
                    .GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
                    .Where(field => field.Name.StartsWith("Public", StringComparison.Ordinal))
                    .Select(field => field.GetRawConstantValue() as string)
            );

            return this;
        }

        public TypeNamesRefactor WithClasses()
        {
            AddNames(
                typeof(TypeNamesRefactorStatic)
                    .GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
                    .Where(field => field.Name.EndsWith("Class", StringComparison.Ordinal))
                    .Select(field => field.GetRawConstantValue() as string)
            );

            return this;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _names.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
