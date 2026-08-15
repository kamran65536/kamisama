# IFindByIdFeature<TEntityDto, TKey>

<a id="ifindbyidfeature-tentitydto-tkey"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IFindByIdFeature.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IFindByIdFeature.cs#L8)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Interface`

## Description

Defines a query that returns one entity DTO by identifier. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IFindByIdFeature<TEntityDto, TKey>
```

## Example

```csharp
ProductDto product = await findProduct.FindByIdAsync(productId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [FindByIdAsync](method-findbyidasync-16.md) | Finds an entity by identifier and returns its &lt;typeparamref name=&quot;TEntityDto&quot;/&gt; representation. Use it with the surrounding package APIs when composing application code. |

