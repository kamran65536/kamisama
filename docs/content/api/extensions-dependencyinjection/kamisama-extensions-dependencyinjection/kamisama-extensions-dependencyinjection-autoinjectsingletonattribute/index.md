# AutoInjectSingletonAttribute

<a id="autoinjectsingletonattribute"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md) | [Back to package index](../../../index.md)

Source: [src/DependencyInjection/AutoInjectSingletonAttribute.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectSingletonAttribute.cs#L9)

Namespace: `KamiSama.Extensions.DependencyInjection`

Kind: `Class`

## Description

Dependency injection attribute for singleton services. Use it on implementations that should be shared for the application lifetime.

## Declaration

```csharp
public class AutoInjectSingletonAttribute : AutoInjectAttributeBase
```

## Example

```csharp
using KamiSama.Extensions.DependencyInjection;

[AutoInjectSingleton(typeof(ICacheService))]
public sealed class MemoryCacheService : ICacheService;
```

## Constructors

### AutoInjectSingletonAttribute

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectSingletonAttribute.cs#L23)

Initializes a singleton registration attribute with an optional explicit service contract. Passing enables service-type inference during assembly scanning.

```csharp
public AutoInjectSingletonAttribute(Type? serviceType);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `serviceType` | `Type?` | `-` | The service contract to register, or to infer it. |

### AutoInjectSingletonAttribute

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectSingletonAttribute.cs#L32)

Initializes a singleton registration attribute that infers its service contract during assembly scanning. The decorated implementation is shared by the dependency injection container.

```csharp
public AutoInjectSingletonAttribute() : this(null);
```

## Parameters

This member does not declare parameters.

## Members

### Properties

| Member | Description |
| --- | --- |
| [ServiceType](property-servicetype-16.md) | Gets or sets the service contract used for the singleton registration. When it is , the contract is inferred from the implementation type and its interfaces. |

