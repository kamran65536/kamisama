# 2. KamiSama.Extensions.DependencyInjection
This library is an simple extension on Microsoft.Extensions.DependencyInjection library. Currently this library only includes named services, but new features will be added if needed.

## Index
- [Named Injection](#21-named-injection)
- [AutoAddDependencies](#22-autoadddependencies)

## 2.1 Named Injection (deprecated)
you can inject implementations by name.
```csharp
// adds a singleton with name instance1
services.AddSingleton<IMyInterface, SomeType>("instance1");
// adds a transient with name instance2
services.AddTransient<IMyInterface, AnotherType>("instance2");
// adds a scoped with name instanc3
services.AddScoped<IMyInterface, ScopedType>("instance3");
```
Note that you cannot use this feature for automatic injection. The only way to use it is through IServiceProvider
```csharp
instance = serviceProvider.GetService("instance2");
```
## 2.2 AutoAddDependencies
Add InjectAttribute to the implementation.
```
[AutoInject(typeof(SampleInerface), ServiceLifetime.Transient)]
public class Implementation : SampleInterface {... }
```
then add the following to the service collection:
```
services.AutoAddDependencies();
```
it will automatically adds all dependencies by InjectAttribute.
