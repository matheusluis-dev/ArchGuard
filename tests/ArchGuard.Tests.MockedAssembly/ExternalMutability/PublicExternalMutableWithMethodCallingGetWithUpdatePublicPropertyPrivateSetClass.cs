namespace ArchGuard.Tests.MockedAssembly.ExternalMutability
{
    public class PublicExternalMutableWithMethodCallingGetWithUpdatePublicPropertyPrivateSetClass
    {
        private string _string;

        private string String
        {
            get
            {
                _string = nameof(_string);
                return string.Empty;
            }
        }

        public string GetString()
        {
            return String;
        }
    }
}
