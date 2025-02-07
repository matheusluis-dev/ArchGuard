namespace ArchGuard
{
    using ArchGuard.Core.Slice.Models;

    public interface ISliceGetResult
    {
        SliceAssertionResult GetResult();
        SliceAssertionResult GetResult(StringComparison comparison);
    }
}
