namespace ArchGuard.Tests.MockedAssembly.ExternalMutability
{
    public class PublicExternalImmutableWithPrivateFieldNonReadonlyClass
    {
        private string _string;

        public PublicExternalImmutableWithPrivateFieldNonReadonlyClass(string @string)
        {
            SetString(@string);
        }

        private void SetString(string @string)
        {
            _string = @string;
        }
    }
}
