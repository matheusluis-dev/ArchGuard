namespace ArchGuard.Library.Extensions
{
    using System;
    using System.Text;

    public static class TypeExtensions
    {
        public static string GetFullName(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            var sb = new StringBuilder();
            AppendNamespaceAndName(type, sb);
            return sb.ToString();
        }

        private static void AppendNamespaceAndName(Type type, StringBuilder sb)
        {
            if (type.IsNested)
            {
                AppendNamespaceAndName(type.DeclaringType, sb);
                sb.Append('+');
            }
            else if (!string.IsNullOrEmpty(type.Namespace))
            {
                sb.Append(type.Namespace).Append('.');
            }

            var name = type.Name;
            var genericIndex = name.IndexOf('`');
            if (genericIndex > 0)
            {
                name = name.Substring(0, genericIndex);
            }

            sb.Append(name);
        }
    }
}
