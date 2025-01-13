namespace ArchGuard.Tests.MockedAssembly.Staticless
{
    public class PublicNonStaticlessClass
    {
        public const bool STATICLESS = false;

        public static bool IsStaticless()
        {
            return STATICLESS;
        }
    }
}
