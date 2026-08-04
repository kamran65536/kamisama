# AutoInjectScopedAttribute<TServiceType>

<a id="autoinjectscopedattribute-tservicetype"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md) | [Back to package index](../../../index.md)

Source: [src/DependencyInjection/AutoInjectScopedAttribute.cs:30](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectScopedAttribute.cs#L30)

Namespace: `KamiSama.Extensions.DependencyInjection`

Kind: `Class`

## Description

Dependency injection attribute for scoped services. Use it on implementations that should be created once per request or scope.

## Declaration

```csharp
public class AutoInjectScopedAttribute<TServiceType>() : AutoInjectScopedAttribute(typeof(TServiceType));
```

## Example

```csharp
using KamiSama.Extensions.DependencyInjection;

[AutoInjectScoped<IProductService>]
public sealed class ProductService : IProductService;
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectScopedAttribute.cs#L30)

AutoInject Scoped Attribute using generic service type. Use it with the surrounding package APIs when composing application code.

```csharp
public class AutoInjectScopedAttribute<TServiceType>() : AutoInjectScopedAttribute(typeof(TServiceType));
```

## Parameters

This member does not declare parameters.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

