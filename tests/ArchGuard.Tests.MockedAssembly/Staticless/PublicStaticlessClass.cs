namespace ArchGuard.Tests.MockedAssembly.Staticless
{
    public class PublicStaticlessClass
    {
        public string String { get; private set; }

        public PublicStaticlessClass(string @string)
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
