namespace ArchGuard.Library
{
    using System;
    using System.IO;
    using System.Reflection;
    using ArchGuard.Library.Helpers;

    public sealed class AssemblySpec
    {
        private readonly Assembly _assembly;

        public string FullName => _assembly.FullName;

        public DirectoryInfo Location { get; }
        public string CodeBaseLocation { get; }

        public AssemblySpec(Assembly assembly)
        {
            _assembly = assembly;

            var location = string.Empty;
#if NET48
            location = _assembly.CodeBase.Replace("file:///", string.Empty);
#else
            location = _assembly.Location;
#endif

            var dll = _assembly.ManifestModule.Name;
            var dllName = dll.Replace(".dll", string.Empty);

            var dir = new DirectoryInfo(location);
            var parent = dir.Parent;
            var dir1 = DirectoryHelper.GetDirectoryInSolution(dllName);

            Location = dir1;

            Console.WriteLine();
        }
    }
}
