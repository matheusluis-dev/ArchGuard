namespace ArchGuard.Tests.MockedAssembly.Stateless
{
    public class PublicStatelessClass
    {
        public const bool STATELESS = true;

        public static bool IsStateless()
        {
            return STATELESS;
        }
    }
}
