namespace ArchGuard.MockedAssembly.Inherit;

public class Class1;

public class InheritClass1 : Class1;

public class DoNotInheritClass1;

public interface IInterface1;

public interface IInheritInterface1 : IInterface1;

public interface IDoNotInheritInterface1;

public class ImplementIInterface1 : IInheritInterface1;

public class GenericParentClass<T>;

public class InheritGenericParentClass : GenericParentClass<string>;
