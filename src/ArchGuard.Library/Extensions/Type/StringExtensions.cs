namespace ArchGuard.Library.Extensions.Type
{
    using System.IO;

    internal static class StringExtensions
    {
        internal static string BetweenDirectorySeparator(this string path)
        {
            return $"{Path.DirectorySeparatorChar}{path}{Path.DirectorySeparatorChar}";
        }
    }
}
