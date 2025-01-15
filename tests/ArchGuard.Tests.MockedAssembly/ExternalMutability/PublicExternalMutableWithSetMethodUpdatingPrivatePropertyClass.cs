namespace ArchGuard.Tests.MockedAssembly.ExternalMutability
{
    public class PublicExternalMutableWithSetMethodUpdatingPrivatePropertyClass
    {
        private string String { get; set; }

        public decimal Decimal
        {
            set { String = nameof(String); }
        }

        public int Int
        {
            set { Decimal = 0m; }
        }
    }
}
