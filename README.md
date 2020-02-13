A repro for issue https://github.com/dotnet/SqlClient/issues/426

Steps:
`msbuild .\ConsoleApp1.sln`
`pushd .\ConsoleApp1\bin\Debug\`
`.\ConsoleApp1.exe`

Expected output:
```
Unhandled Exception: System.Reflection.TargetInvocationException: Exception has been thrown by the target of an invocation. 
    ---> System.Reflection.TargetInvocationException: Exception has been thrown by the target of an invocation. 
    ---> System.TypeInitializationException: The type initializer for 'Microsoft.Data.SqlClient.SqlConnection' threw an exception. 
    ---> System.TypeInitializationException: The type initializer for 'Microsoft.Data.SqlClient.SqlConnectionFactory' threw an exception. 
    ---> System.TypeInitializationException: The type initializer for 'Microsoft.Data.SqlClient.SqlPerformanceCounters' threw an exception. 
    ---> System.TypeInitializationException: The type initializer for 'Microsoft.Data.Common.ADP' threw an exception. 
    ---> System.IO.FileNotFoundException: Could not load file or assembly 'Microsoft.Data.SqlClient.resources, Version=1.10.19324.4, Culture=en-US, PublicKeyToken=23ec7fc2d6eaa4a5' or one of its dependencies. The system cannot find the file specified. 
    ---> System.IO.FileNotFoundException: Could not load file or assembly 'Microsoft.Data.SqlClient.resources' or one of its dependencies. The system cannot find the file specified.
        at System.Reflection.RuntimeAssembly._nLoad(AssemblyName fileName, String codeBase, Evidence assemblySecurity, RuntimeAssembly locationHint, StackCrawlMark& stackMark, IntPtr pPrivHostBinder, Boolean throwOnFileNotFound, Boolean forIntrospection, Boolean suppressSecurityChecks)
        at System.Reflection.RuntimeAssembly.nLoad(AssemblyName fileName, String codeBase, Evidence assemblySecurity, RuntimeAssembly locationHint, StackCrawlMark& stackMark, IntPtr pPrivHostBinder, Boolean throwOnFileNotFound, Boolean forIntrospection, Boolean suppressSecurityChecks)
        at System.Reflection.RuntimeAssembly.InternalLoadAssemblyName(AssemblyName assemblyRef, Evidence assemblySecurity, RuntimeAssembly reqAssembly, StackCrawlMark& stackMark, IntPtr pPrivHostBinder, Boolean throwOnFileNotFound, Boolean forIntrospection, Boolean suppressSecurityChecks)
        at System.Reflection.RuntimeAssembly.InternalLoad(String assemblyString, Evidence assemblySecurity, StackCrawlMark& stackMark, IntPtr pPrivHostBinder, Boolean forIntrospection)
        at System.Reflection.RuntimeAssembly.InternalLoad(String assemblyString, Evidence assemblySecurity, StackCrawlMark& stackMark, Boolean forIntrospection)
        at System.Reflection.Assembly.Load(String assemblyString)
        at ConsoleApp1.DatabaseMigrator.RedirectToFile(Object sender, ResolveEventArgs args) in C:\Users\Brad\source\repos\ConsoleApp1\ConsoleApp1\Program.cs:line 44
        at System.AppDomain.OnAssemblyResolveEvent(RuntimeAssembly assembly, String assemblyFullName)
        --- End of inner exception stack trace ---
        at System.Reflection.RuntimeAssembly._nLoad(AssemblyName fileName, String codeBase, Evidence assemblySecurity, RuntimeAssembly locationHint, StackCrawlMark& stackMark, IntPtr pPrivHostBinder, Boolean throwOnFileNotFound, Boolean forIntrospection, Boolean suppressSecurityChecks)
        at System.Reflection.RuntimeAssembly.InternalGetSatelliteAssembly(String name, CultureInfo culture, Version version, Boolean throwOnFileNotFound, StackCrawlMark& stackMark)
        at System.Resources.ManifestBasedResourceGroveler.GetSatelliteAssembly(CultureInfo lookForCulture, StackCrawlMark& stackMark)
        at System.Resources.ManifestBasedResourceGroveler.GrovelForResourceSet(CultureInfo culture, Dictionary`2 localResourceSets, Boolean tryParents, Boolean createIfNotExists, StackCrawlMark& stackMark)
        at System.Resources.ResourceManager.InternalGetResourceSet(CultureInfo requestedCulture, Boolean createIfNotExists, Boolean tryParents, StackCrawlMark& stackMark)
        at System.Resources.ResourceManager.InternalGetResourceSet(CultureInfo culture, Boolean createIfNotExists, Boolean tryParents)
        at System.Resources.ResourceManager.GetString(String name, CultureInfo culture)
        at System.Strings.get_AZURESQL_GenericEndpoint() in E:\agent1\_work\31\s\src\Microsoft.Data.SqlClient\netfx\src\Resources\Strings.Designer.cs:line 1850
        at Microsoft.Data.Common.ADP..cctor() in E:\agent1\_work\31\s\src\Microsoft.Data.SqlClient\netfx\src\Microsoft\Data\Common\AdapterUtil.cs:line 3016
        --- End of inner exception stack trace ---
        at Microsoft.Data.ProviderBase.DbConnectionPoolCounters..ctor(String categoryName, String categoryHelp) in E:\agent1\_work\31\s\src\Microsoft.Data.SqlClient\netfx\src\Microsoft\Data\ProviderBase\DbConnectionPoolCounters.cs:line 187         at Microsoft.Data.SqlClient.SqlPerformanceCounters..ctor() in E:\agent1\_work\31\s\src\Microsoft.Data.SqlClient\netfx\src\Microsoft\Data\SqlClient\SqlConnectionFactory.cs:line 379
        at Microsoft.Data.SqlClient.SqlPerformanceCounters..cctor() in E:\agent1\_work\31\s\src\Microsoft.Data.SqlClient\netfx\src\Microsoft\Data\SqlClient\SqlConnectionFactory.cs:line 376
        --- End of inner exception stack trace ---
        at Microsoft.Data.SqlClient.SqlConnectionFactory..ctor() in E:\agent1\_work\31\s\src\Microsoft.Data.SqlClient\netfx\src\Microsoft\Data\SqlClient\SqlConnectionFactory.cs:line 20
        at Microsoft.Data.SqlClient.SqlConnectionFactory..cctor() in E:\agent1\_work\31\s\src\Microsoft.Data.SqlClient\netfx\src\Microsoft\Data\SqlClient\SqlConnectionFactory.cs:line 24
        --- End of inner exception stack trace ---
        at Microsoft.Data.SqlClient.SqlConnection..cctor() in E:\agent1\_work\31\s\src\Microsoft.Data.SqlClient\netfx\src\Microsoft\Data\ProviderBase\SqlConnectionHelper.cs:line 19
        --- End of inner exception stack trace ---
        at Microsoft.Data.SqlClient.SqlConnection..ctor() in E:\agent1\_work\31\s\src\Microsoft.Data.SqlClient\netfx\src\Microsoft\Data\ProviderBase\SqlConnectionHelper.cs:line 28
        at ClassLibrary1.Class1..ctor() in C:\Users\Brad\source\repos\ConsoleApp1\ClassLibrary1\Class1.cs:line 10
        --- End of inner exception stack trace ---
        at System.RuntimeTypeHandle.CreateInstance(RuntimeType type, Boolean publicOnly, Boolean noCheck, Boolean& canBeCached, RuntimeMethodHandleInternal& ctor, Boolean& bNeedSecurityCheck)
        at System.RuntimeType.CreateInstanceSlow(Boolean publicOnly, Boolean skipCheckThis, Boolean fillCache, StackCrawlMark& stackMark)
        at System.RuntimeType.CreateInstanceDefaultCtor(Boolean publicOnly, Boolean skipCheckThis, Boolean fillCache, StackCrawlMark& stackMark)
        at System.Activator.CreateInstance(Type type, Boolean nonPublic)
        at System.Activator.CreateInstance(Type type)
        at ConsoleApp1.DatabaseMigrator..ctor(String assemblyPath, String typeName) in C:\Users\Brad\source\repos\ConsoleApp1\ConsoleApp1\Program.cs:line 33
        --- End of inner exception stack trace ---
        at System.RuntimeMethodHandle.InvokeMethod(Object target, Object[] arguments, Signature sig, Boolean constructor)       at System.Reflection.RuntimeConstructorInfo.Invoke(BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
        at System.RuntimeType.CreateInstanceImpl(BindingFlags bindingAttr, Binder binder, Object[] args, CultureInfo culture, Object[] activationAttributes, StackCrawlMark& stackMark)
        at System.Activator.CreateInstance(Type type, BindingFlags bindingAttr, Binder binder, Object[] args, CultureInfo culture, Object[] activationAttributes)
        at System.Activator.CreateInstanceFromInternal(String assemblyFile, String typeName, Boolean ignoreCase, BindingFlags bindingAttr, Binder binder, Object[] args, CultureInfo culture, Object[] activationAttributes, Evidence securityInfo)     at System.AppDomain.CreateInstanceFrom(String assemblyFile, String typeName, Boolean ignoreCase, BindingFlags bindingAttr, Binder binder, Object[] args, CultureInfo culture, Object[] activationAttributes)
        at System.AppDomain.CreateInstanceFromAndUnwrap(String assemblyFile, String typeName, Boolean ignoreCase, BindingFlags bindingAttr, Binder binder, Object[] args, CultureInfo culture, Object[] activationAttributes)
        at System.AppDomain.CreateInstanceFromAndUnwrap(String assemblyFile, String typeName, Boolean ignoreCase, BindingFlags bindingAttr, Binder binder, Object[] args, CultureInfo culture, Object[] activationAttributes)
        at ConsoleApp1.Program.Main(String[] args) in C:\Users\Brad\source\repos\ConsoleApp1\ConsoleApp1\Program.cs:line 17
```