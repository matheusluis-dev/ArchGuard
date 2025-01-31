namespace ArchGuard.MockedAssembly.AccessModifiers.File
{
    public class PublicClass;

    internal class InternalClass;

    file class FileClass;

    public class PublicParentClass
    {
        public class PublicNestedClass;

        internal class InternalNestedClass;

        protected class ProtectedNestedClass;

        protected internal class ProtectedInternalNestedClass;

        private class PrivateNestedClass;
    }

    internal class InternalParentClass
    {
        public class PublicNestedClass;

        internal class InternalNestedClass;

        protected class ProtectedNestedClass;

        protected internal class ProtectedInternalNestedClass;

        private class PrivateNestedClass;
    }

    file class FileParentClass
    {
        public class PublicNestedClass;

        internal class InternalNestedClass;

        protected class ProtectedNestedClass;

        protected internal class ProtectedInternalNestedClass;

        private class PrivateNestedClass;
    }
}
