# 2. KamiSama.Extensions.DependencyInjection
This library is an simple extension on Microsoft.Extensions.DependencyInjection library. Currently this library only includes named services, but new features will be added if needed.

## Index
- AutoAddDependencies

## 2.1 AutoAddDependencies
Add InjectAttribute to the implementation.
```
[AutoInject(typeof(SampleInerface), ServiceLifetime.Transient)]
public class Implementation : SampleInterface {... }
```
then add the following to the service collection:
```
services.AutoAddDependencies<SomeType>();
```
it will automatically adds all dependencies by InjectAttribute.
## 2.2 AutoInjectScoped, AutoInjectTransient, AutoInjectSingleton Attributes
You can also describe the dependency lifetime directly using these attributes:
```csharp
[AutoInjectScoped(typeof(ISomeService))]
internal class ScopedImplementation : ISomeService
{
}
```
or you can simply say:
```csharp
[AutoInjectScoped<ISomeService>]
internal class ScopedImplementation : ISomeService
{
}
```