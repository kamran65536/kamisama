# AutoInjectScopedAttribute

<a id="autoinjectscopedattribute"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md) | [Back to package index](../../../index.md)

Source: [src/DependencyInjection/AutoInjectScopedAttribute.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectScopedAttribute.cs#L8)

Namespace: `KamiSama.Extensions.DependencyInjection`

Kind: `Class`

## Description

Dependency injection attribute for scoped services. Use it on implementations that should be created once per request or scope.

## Declaration

```csharp
public class AutoInjectScopedAttribute : AutoInjectAttributeBase
```

## Example

```csharp
using KamiSama.Extensions.DependencyInjection;

[AutoInjectScoped<IProductService>]
public sealed class ProductService : IProductService;
```

## Constructors

### AutoInjectScopedAttribute

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectScopedAttribute.cs#L17)

Initializes a new `AutoInjectScopedAttribute` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public AutoInjectScopedAttribute(Type? serviceType);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `serviceType` | `Type?` | `-` | The `serviceType` value passed to this member. |

### AutoInjectScopedAttribute

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectScopedAttribute.cs#L23)

Initializes a new `AutoInjectScopedAttribute` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public AutoInjectScopedAttribute() : this(null);
```

## Parameters

This member does not declare parameters.

## Members

### Properties

| Member | Description |
| --- | --- |
| [ServiceType](property-servicetype-14.md) | Exposes the `ServiceType` value on `AutoInjectScopedAttribute`. Read or set it as part of configuring or using the type. |

