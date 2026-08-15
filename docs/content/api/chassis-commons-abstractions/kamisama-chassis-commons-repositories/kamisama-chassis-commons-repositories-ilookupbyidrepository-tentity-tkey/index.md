# ILookupByIdRepository<TEntity, TKey>

<a id="ilookupbyidrepository-tentity-tkey"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Repositories/ILookupByIdReposiotry.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Repositories/ILookupByIdReposiotry.cs#L8)

Namespace: `KamiSama.Chassis.Commons.Repositories`

Kind: `Interface`

## Description

Defines lookup and existence checks by entity identifier. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface ILookupByIdRepository<TEntity, TKey>
```

## Example

```csharp
Product? product = await products.FindByIdAsync(productId, cancellationToken);
bool exists = await products.ExistsByIdAsync(productId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ExistsByIdAsync](method-existsbyidasync-23.md) | Determines whether an entity with the supplied identifier exists. Use it with the surrounding package APIs when composing application code. |
| [FindByIdAsync](method-findbyidasync-16.md) | Finds an entity by identifier. Use it with the surrounding package APIs when composing application code. |

