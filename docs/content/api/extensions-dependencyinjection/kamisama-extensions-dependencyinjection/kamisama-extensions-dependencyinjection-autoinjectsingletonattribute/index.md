# AutoInjectSingletonAttribute

<a id="autoinjectsingletonattribute"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md) | [Back to package index](../../../index.md)

Source: [src/DependencyInjection/AutoInjectSingletonAttribute.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectSingletonAttribute.cs#L8)

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

[AutoInjectSingleton<ICacheService>]
public sealed class MemoryCacheService : ICacheService;
```

## Constructors

### AutoInjectSingletonAttribute

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectSingletonAttribute.cs#L17)

Initializes a new `AutoInjectSingletonAttribute` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public AutoInjectSingletonAttribute(Type? serviceType);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `serviceType` | `Type?` | `-` | The `serviceType` value passed to this member. |

### AutoInjectSingletonAttribute

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectSingletonAttribute.cs#L23)

Initializes a new `AutoInjectSingletonAttribute` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public AutoInjectSingletonAttribute() : this(null);
```

## Parameters

This member does not declare parameters.

## Members

### Properties

| Member | Description |
| --- | --- |
| [ServiceType](property-servicetype-14.md) | Exposes the `ServiceType` value on `AutoInjectSingletonAttribute`. Read or set it as part of configuring or using the type. |

