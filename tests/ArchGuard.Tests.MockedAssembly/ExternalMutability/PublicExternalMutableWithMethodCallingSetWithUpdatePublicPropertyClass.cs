namespace ArchGuard.Tests.MockedAssembly.ExternalMutability
{
    public class PublicExternalMutableWithMethodCallingSetWithUpdatePublicPropertyClass
    {
        public string String { get; private set; }

        public void SetString()
        {
            String = nameof(String);
        }
    }
}
