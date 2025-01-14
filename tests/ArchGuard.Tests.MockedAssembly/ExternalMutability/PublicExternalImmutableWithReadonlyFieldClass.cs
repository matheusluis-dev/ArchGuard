namespace ArchGuard.Tests.MockedAssembly.ExternalMutability
{
    public class PublicExternalImmutableWithReadonlyFieldClass
    {
        public readonly string _string;

        public PublicExternalImmutableWithReadonlyFieldClass(string @string)
        {
            _string = @string;
        }
    }
}
