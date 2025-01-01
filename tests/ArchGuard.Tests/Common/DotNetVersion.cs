namespace ArchGuard.Tests.Common
{
    public static class DotNetVersion
    {
        public static bool Net5_0OrGreater
        {
            get {
#if NET5_0_OR_GREATER
                return true;
#endif

                return false; }
        }

        public static bool Net7_0OrGreater
        {
            get
            {
#if NET7_0_OR_GREATER
                return true;
#endif
                return false;
            }
        }
    }
}
