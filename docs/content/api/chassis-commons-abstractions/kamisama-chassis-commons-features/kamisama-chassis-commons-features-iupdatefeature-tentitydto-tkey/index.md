# IUpdateFeature<TEntityDto, TKey>

<a id="iupdatefeature-tentitydto-tkey"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IUpdateFeature.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IUpdateFeature.cs#L8)

Namespace: `KamiSama.Chassis.Commons.Features`

Kind: `Interface`

## Description

Defines an update use case for an entity identified by a key. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IUpdateFeature<TEntityDto, TKey>
```

## Example

```csharp
await updateProduct.UpdateAsync(
    productId, new UpdateProductRequest("Keyboard", 120m), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [UpdateAsync](method-updateasync-17.md) | Applies the supplied values to the entity identified by the key. Use it with the surrounding package APIs when composing application code. |

