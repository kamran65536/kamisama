# KamiSama.Extensions.DependencyInjection

[Back to package index](../index.md)

Version: `10.0.0`

## Description

Automatically register attributed service implementations with Microsoft.Extensions.DependencyInjection by scanning selected assemblies. Choose transient, scoped, or singleton lifetimes, keyed or unkeyed registrations, explicit or inferred service types, and single or multiple registrations.

## How to use

```shell
dotnet add package KamiSama.Extensions.DependencyInjection --version 10.0.0
```

Decorate each implementation with the appropriate registration attribute, then scan its assembly during service configuration:

```csharp
using KamiSama.Extensions.DependencyInjection;

[AutoInjectScoped<IProductService>]
public sealed class ProductService : IProductService;

services.AutoAddDependenciesFrom<Program>();
```

## Namespaces

- [KamiSama.Extensions.DependencyInjection](kamisama-extensions-dependencyinjection/index.md) (9 types)

## Types

- [KamiSama.Extensions.DependencyInjection.AutoInjectAttribute](kamisama-extensions-dependencyinjection/kamisama-extensions-dependencyinjection-autoinjectattribute/index.md) - General-purpose dependency injection attribute where service type and lifetime can be configured directly on the implementation type.
- [KamiSama.Extensions.DependencyInjection.AutoInjectAttributeBase](kamisama-extensions-dependencyinjection/kamisama-extensions-dependencyinjection-autoinjectattributebase/index.md) - Base attribute for convention-based dependency injection registration. Derived attributes use it to register the decorated type against an explicit or inferred service type.
- [KamiSama.Extensions.DependencyInjection.AutoInjectScopedAttribute](kamisama-extensions-dependencyinjection/kamisama-extensions-dependencyinjection-autoinjectscopedattribute/index.md) - Dependency injection attribute for scoped services. Use it on implementations that should be created once per request or scope.
- [KamiSama.Extensions.DependencyInjection.AutoInjectScopedAttribute<TServiceType>](kamisama-extensions-dependencyinjection/kamisama-extensions-dependencyinjection-autoinjectscopedattribute-tservicetype/index.md) - Dependency injection attribute for scoped services. Use it on implementations that should be created once per request or scope.
- [KamiSama.Extensions.DependencyInjection.AutoInjectSingletonAttribute](kamisama-extensions-dependencyinjection/kamisama-extensions-dependencyinjection-autoinjectsingletonattribute/index.md) - Dependency injection attribute for singleton services. Use it on implementations that should be shared for the application lifetime.
- [KamiSama.Extensions.DependencyInjection.AutoInjectSingletonAttribute<TService>](kamisama-extensions-dependencyinjection/kamisama-extensions-dependencyinjection-autoinjectsingletonattribute-tservice/index.md) - Dependency injection attribute for singleton services. Use it on implementations that should be shared for the application lifetime.
- [KamiSama.Extensions.DependencyInjection.AutoInjectTransientAttribute](kamisama-extensions-dependencyinjection/kamisama-extensions-dependencyinjection-autoinjecttransientattribute/index.md) - Dependency injection attribute for transient services. Use it on implementations that should be created each time they are requested.
- [KamiSama.Extensions.DependencyInjection.AutoInjectTransientAttribute<TService>](kamisama-extensions-dependencyinjection/kamisama-extensions-dependencyinjection-autoinjecttransientattribute-tservice/index.md) - Dependency injection attribute for transient services. Use it on implementations that should be created each time they are requested.
- [KamiSama.Extensions.DependencyInjection.ServiceCollectionExtensions](kamisama-extensions-dependencyinjection/kamisama-extensions-dependencyinjection-servicecollectionextensions/index.md) - Assembly-scanning extensions for registering implementations decorated with `AutoInjectAttributeBase`. Scan explicit assemblies or use marker types to select one or two assemblies.
