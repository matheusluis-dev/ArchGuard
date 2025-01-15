namespace ArchGuard.Tests.Common.Extensions
{
    using System.Collections.Generic;

    public static class StringExtensions
    {
        public static IList<string> ToList(this string str)
        {
            return new List<string> { str };
        }
    }
}
