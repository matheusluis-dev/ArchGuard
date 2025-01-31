namespace ArchGuard.Extensions.NFluent
{
    public static class NFluentExtensions
    {
        public static void IsSuccess(this ICheck<TypeAssertionResult> result)
        {
            result.WhichMember(member => member.IsSuccessful);
        }
    }
}
