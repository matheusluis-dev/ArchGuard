namespace ArchGuard.Kernel.Results
{
    using System;

    public sealed class Result<T>
        where T : class
    {
        private T _value = null!;
        public T Value
        {
            get
            {
                ArgumentNullException.ThrowIfNull(_value);
                return _value;
            }
            private set => _value = value;
        }

        public bool IsSuccess => _value is not null && Error is null;

        public Error? Error { get; private set; }

        private Result(T value)
        {
            Value = value;
        }

        private Result(Error error)
        {
            Error = error;
        }

        public static Result<T> Success(T value)
        {
            return new(value);
        }

        public static Result<T> Failure(Error error)
        {
            return new(error);
        }
    }
}
