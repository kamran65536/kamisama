# IDeleteFeature<TKey>

<a id="ideletefeature-tkey"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IDeleteFeature.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IDeleteFeature.cs#L6)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Interface`

## Description

Defines a use case that deletes an entity identified by a key. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IDeleteFeature<TKey>
```

## Example

```csharp
await deleteProduct.DeleteAsync(productId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [DeleteAsync](method-deleteasync-14.md) | Deletes the entity identified by the supplied key. Use it with the surrounding package APIs when composing application code. |

