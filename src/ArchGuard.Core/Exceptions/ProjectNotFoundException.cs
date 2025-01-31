namespace ArchGuard.Exceptions
{
    using System;
    using ArchGuard.Core.Results;

    public sealed class ProjectNotFoundException : Exception
    {
        public ProjectNotFoundException(Error error)
            : base(error?.ToString()) { }

        public ProjectNotFoundException(Error error, Exception innerException)
            : base(error?.ToString(), innerException) { }

        private ProjectNotFoundException() { }

        private ProjectNotFoundException(string message)
            : base(message) { }

        private ProjectNotFoundException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
