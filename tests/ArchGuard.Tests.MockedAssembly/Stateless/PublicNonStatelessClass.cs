namespace ArchGuard.Tests.MockedAssembly.Stateless
{
    public class PublicNonStatelessClass
    {
        public string String { get; private set; }

        public PublicNonStatelessClass(string @string)
        {
            String = @string;
        }

        public string UpdateString(string @string)
        {
            String = @string;
            return String;
        }
    }
}
