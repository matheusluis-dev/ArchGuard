namespace ArchGuard.Tests.MockedAssembly.ExternalMutability
{
    public class PublicExternalMutableWithGetMethodUpdatingPrivateFieldClass
    {
        private string _string;

        public string String
        {
            get
            {
                _string = nameof(_string);
                return string.Empty;
            }
        }
    }
}
