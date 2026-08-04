# AutoInjectAttribute

<a id="autoinjectattribute"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md) | [Back to package index](../../../index.md)

Source: [src/DependencyInjection/AutoInjectAttribute.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectAttribute.cs#L6)

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
| [Lifetime](property-lifetime-16.md) | Service Lifetime (default is Transient). Use it with the surrounding package APIs when composing application code. |
| [ServiceType](property-servicetype-12.md) | Exposes the `ServiceType` value on `AutoInjectAttribute`. Read or set it as part of configuring or using the type. |

