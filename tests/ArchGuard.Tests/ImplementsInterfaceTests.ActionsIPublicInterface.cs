namespace ArchGuard.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using ArchGuard.Tests.Common;
    using ArchGuard.Tests.Common.Extensions;
    using ArchGuard.Tests.MockedAssembly.Interfaces.Public;

    public sealed partial class ImplementsInterfaceTests
    {
        public class ActionsIPublicInterface : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                Func<IEnumerable<string>> generic = () =>
                    TypesFromMockedAssembly
                        .All.That()
                        .ImplementsInterface<IPublicInterface>()
                        .GetTypes()
                        .GetFullNames();

#pragma warning disable CA2263 // Prefer generic overload when type is known
                Func<IEnumerable<string>> @explicit = () =>
                    TypesFromMockedAssembly
                        .All.That()
                        .ImplementsInterface(typeof(IPublicInterface))
                        .GetTypes()
                        .GetFullNames();
#pragma warning restore CA2263 // Prefer generic overload when type is known

                yield return new object[] { generic };
                yield return new object[] { @explicit };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
