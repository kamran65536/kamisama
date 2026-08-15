# AutoInjectAttribute

<a id="autoinjectattribute"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md) | [Back to package index](../../../index.md)

Source: [src/DependencyInjection/AutoInjectAttribute.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectAttribute.cs#L7)

Namespace: `KamiSama.Extensions.DependencyInjection`

Kind: `Class`

## Description

General-purpose dependency injection attribute where service type and lifetime can be configured directly on the implementation type.

## Declaration

```csharp
public class AutoInjectAttribute : AutoInjectAttributeBase
```

## Example

```csharp
using KamiSama.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[AutoInject(ServiceType = typeof(IProductService), Lifetime = ServiceLifetime.Scoped)]
public sealed class ProductService : IProductService;
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [Lifetime](property-lifetime-19.md) | Gets or sets the lifetime of the generated service registration. The default lifetime is `ServiceLifetime.Transient`. |
| [ServiceType](property-servicetype-14.md) | Gets or sets the service contract used for registration. When it is , the contract is inferred from the implementation type and its interfaces. |

