namespace ArchGuard.Exceptions
{
    using System;
    using ArchGuard.Core.Results;

    public sealed class SolutionNotFoundException : Exception
    {
        public SolutionNotFoundException(Error error)
            : base(error?.ToString()) { }

        public SolutionNotFoundException(Error error, Exception innerException)
            : base(error?.ToString(), innerException) { }

        private SolutionNotFoundException() { }

        private SolutionNotFoundException(string message)
            : base(message) { }

        private SolutionNotFoundException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
