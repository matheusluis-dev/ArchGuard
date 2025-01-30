namespace ArchGuard.MockedAssembly.AccessModifiers.Public
{
    public class PublicClass;

    internal class InternalClass;

    file class FileClass;

    public class PublicParentClass
    {
        public class PublicNestedClass;

        internal class InternalNestedClass;

        protected class ProtectedNestedClass;

        private class PrivateNestedClass;
    }

    internal class InternalParentClass
    {
        public class PublicNestedClass;

        internal class InternalNestedClass;

        protected class ProtectedNestedClass;

        private class PrivateNestedClass;
    }
}
