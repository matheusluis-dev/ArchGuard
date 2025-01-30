namespace ArchGuard
{
    using System;

    internal sealed class Result<T>
        where T : class
    {
        private T _value = null!;
        internal T Value
        {
            get
            {
                ArgumentNullException.ThrowIfNull(_value);
                return _value;
            }
            private set => _value = value;
        }

        internal bool IsSuccess => _value is not null && Error is null;

        internal Error? Error { get; private set; }

        private Result(T value)
        {
            Value = value;
        }

        private Result(Error error)
        {
            Error = error;
        }

        internal static Result<T> Success(T value)
        {
            return new(value);
        }

        internal static Result<T> Failure(Error error)
        {
            return new(error);
        }
    }
}
