# IExistsByIdFeature<TKey>

<a id="iexistsbyidfeature-tkey"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IExistsByIdFeature.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IExistsByIdFeature.cs#L7)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Interface`

## Description

Defines an existence check for an entity identifier. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IExistsByIdFeature<TKey>
```

## Example

```csharp
bool exists = await productExists.ExistsByIdAsync(productId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ExistsByIdAsync](method-existsbyidasync-15.md) | Determines whether an entity with the supplied identifier exists. Use it with the surrounding package APIs when composing application code. |

