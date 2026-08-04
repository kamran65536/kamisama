# KamiSama.Extensions.DependencyInjection

[Back to package index](../index.md)

Version: `10.0.10`

## Description

Attribute-based dependency injection helpers for automatically registering services from assemblies. Use it to mark implementations with scoped, transient, or singleton service lifetimes.

## Install

```shell
dotnet add package KamiSama.Extensions.DependencyInjection --version 10.0.10
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
- [KamiSama.Extensions.DependencyInjection.ServiceCollectionExtensions](kamisama-extensions-dependencyinjection/kamisama-extensions-dependencyinjection-servicecollectionextensions/index.md) - Service Collection Extension for named implementations. Use it with the surrounding package APIs when composing application code.
