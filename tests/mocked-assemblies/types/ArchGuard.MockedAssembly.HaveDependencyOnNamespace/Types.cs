namespace ArchGuard.MockedAssembly.HaveDependencyOnNamespace.NamespaceA
{
    public class Class
    {
        NamespaceB.Class ClassNamespaceB { get; set; }
    }
}

namespace ArchGuard.MockedAssembly.HaveDependencyOnNamespace.NamespaceB
{
    public class Class { }

    public class AnotherClass { }
}

namespace ArchGuard.MockedAssembly.HaveDependencyOnNamespace.NamespaceB.SubNamespace
{
    public class SubClass
    {
        NamespaceB.Class NamespaceBClass { get; set; }
    }
}

namespace ArchGuard.MockedAssembly.HaveDependencyOnNamespace.NamespaceC
{
    public class Class
    {
        NamespaceA.Class ClassNamespaceA { get; set; }
    }
}
