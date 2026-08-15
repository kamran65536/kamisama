# AutoInjectScopedAttribute

<a id="autoinjectscopedattribute"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md) | [Back to package index](../../../index.md)

Source: [src/DependencyInjection/AutoInjectScopedAttribute.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectScopedAttribute.cs#L9)

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

[AutoInjectScoped(typeof(IProductService))]
public sealed class ProductService : IProductService;
```

## Constructors

### AutoInjectScopedAttribute

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectScopedAttribute.cs#L23)

Initializes a scoped registration attribute with an optional explicit service contract. Passing enables service-type inference during assembly scanning.

```csharp
public AutoInjectScopedAttribute(Type? serviceType);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `serviceType` | `Type?` | `-` | The service contract to register, or to infer it. |

### AutoInjectScopedAttribute

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectScopedAttribute.cs#L32)

Initializes a scoped registration attribute that infers its service contract during assembly scanning. The decorated implementation is registered once per dependency injection scope.

```csharp
public AutoInjectScopedAttribute() : this(null);
```

## Parameters

This member does not declare parameters.

## Members

### Properties

| Member | Description |
| --- | --- |
| [ServiceType](property-servicetype-16.md) | Gets or sets the service contract used for the scoped registration. When it is , the contract is inferred from the implementation type and its interfaces. |

