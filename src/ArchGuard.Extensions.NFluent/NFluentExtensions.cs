namespace ArchGuard.Extensions.NFluent
{
    using ArchGuard.Core.Field.Models;
    using ArchGuard.Core.Method.Models;
    using ArchGuard.Core.Type.Models;

    public static class NFluentExtensions
    {
        public static void IsSuccess(this ICheck<TypeAssertionResult> result)
        {
            result.WhichMember(member => member.IsSuccessful);
        }

        public static void IsSuccess(this ICheck<MethodAssertionResult> result)
        {
            result.WhichMember(member => member.IsSuccessful);
        }

        public static void IsSuccess(this ICheck<FieldAssertionResult> result)
        {
            result.WhichMember(member => member.IsSuccessful);
        }
    }
}
