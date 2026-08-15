# AutoInjectScopedAttribute<TServiceType>

<a id="autoinjectscopedattribute-tservicetype"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.DependencyInjection](../../index.md) | [Back to package index](../../../index.md)

Source: [src/DependencyInjection/AutoInjectScopedAttribute.cs:41](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectScopedAttribute.cs#L41)

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

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/DependencyInjection/AutoInjectScopedAttribute.cs#L41)

Marks an implementation for automatic scoped registration under &lt;typeparamref name=&quot;TServiceType&quot;/&gt;. The generic argument supplies the service contract without a `Type` constructor argument.

```csharp
public class AutoInjectScopedAttribute<TServiceType>() : AutoInjectScopedAttribute(typeof(TServiceType));
```

## Parameters

This member does not declare parameters.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

