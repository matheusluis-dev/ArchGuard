namespace ArchGuard.Tests.MockedAssembly.ExternalMutability
{
    public class PublicExternalMutableWithMethodUpdatingPrivateFieldClass
    {
        private string _string;

        public PublicExternalMutableWithMethodUpdatingPrivateFieldClass(string @string)
        {
            SetString(@string);
        }

        public void SetString(string @string)
        {
            _string = @string;
        }
    }
}
