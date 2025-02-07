namespace ArchGuard
{
    public interface ISliceAssertionRule
    {
        ISliceAssertionSequence NotHaveDependenciesBetweenSlices();
    }
}
