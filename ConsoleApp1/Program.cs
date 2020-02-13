using System;
using System.IO;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {;
            var loadPath = Path.GetFullPath("..\\..\\..\\ClassLibrary1\\bin\\Debug\\");
            var setupInformation = new AppDomainSetup
            {
                ApplicationBase = loadPath
            };
            var appDomain = AppDomain.CreateDomain("Foo", AppDomain.CurrentDomain.Evidence, setupInformation);
            var migrator = appDomain.CreateInstanceFromAndUnwrap(
                    Path.Combine(loadPath, "ConsoleApp1.exe"),
                    "ConsoleApp1.DatabaseMigrator",
                    false, 0, null,
                    new[] { Path.Combine(loadPath, "ClassLibrary1.dll"), "ClassLibrary1.Class1" }, null, null);
        }
    }

    // this class is loaded into a new app domain, to load the destination type in a "clean room", free from the assemblies of the root app domain.
    public class DatabaseMigrator : MarshalByRefObject
    {
        public DatabaseMigrator(string assemblyPath, string typeName)
        {
            AppDomain.CurrentDomain.AssemblyResolve += RedirectToFile;
            var assembly = Assembly.LoadFrom(assemblyPath);
            var type = assembly.GetType(typeName);
            var instance = Activator.CreateInstance(assembly.GetType(typeName));
        }

        private static Assembly RedirectToFile(object sender, ResolveEventArgs args)
        {
            var name = new AssemblyName(args.Name);

            // if we failed to resolve a simple name, nothing we can do
            if (name.Name.Equals(name.FullName)) return null;

            // load the simple name, effectively a binding redirect to whatever version is adjacent to the migrator dll.
            return Assembly.Load(name.Name);
        }
    }
}
