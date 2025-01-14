namespace ArchGuard.Tests.MockedAssembly.ExternalMutability
{
    public class PublicExternalMutableWithSetMethodUpdatingPrivateFieldClass
    {
        private string _string;

        public string String
        {
            private get { return string.Empty; }
            set { _string = nameof(_string); }
        }
    }
}
