# AutoInjectSingletonAttribute<TService>

<a id="autoinjectsingletonattribute-tservice"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md) | [Back to package index](../../../index.md)

Source: [src/DependencyInjection/AutoInjectSingletonAttribute.cs:31](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectSingletonAttribute.cs#L31)

Namespace: `KamiSama.Extensions.DependencyInjection`

Kind: `Class`

## Description

Dependency injection attribute for singleton services. Use it on implementations that should be shared for the application lifetime.

## Declaration

```csharp
public class AutoInjectSingletonAttribute<TService>() : AutoInjectSingletonAttribute(typeof(TService));
```

## Example

```csharp
using KamiSama.Extensions.DependencyInjection;

[AutoInjectSingleton<ICacheService>]
public sealed class MemoryCacheService : ICacheService;
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectSingletonAttribute.cs#L31)

AutoInject Singleton Attribute with generic service type. Use it with the surrounding package APIs when composing application code.

```csharp
public class AutoInjectSingletonAttribute<TService>() : AutoInjectSingletonAttribute(typeof(TService));
```

## Parameters

This member does not declare parameters.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

