namespace ArchGuard
{
    public interface IVerify
    {
        IMethodFilterEntryPoint Methods { get; }
        IFieldFilterEntryPoint Fields { get; }
        IPropertyFilterEntryPoint Properties { get; }
    }
}
