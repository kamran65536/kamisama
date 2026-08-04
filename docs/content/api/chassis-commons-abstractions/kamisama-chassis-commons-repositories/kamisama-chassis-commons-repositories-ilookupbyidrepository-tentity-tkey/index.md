# ILookupByIdRepository<TEntity, TKey>

<a id="ilookupbyidrepository-tentity-tkey"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Repositories/ILookupByIdReposiotry.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Repositories/ILookupByIdReposiotry.cs#L6)

Namespace: `KamiSama.Chassis.Commons.Repositories`

Kind: `Interface`

## Description

Repository with find by Id feature. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface ILookupByIdRepository<TEntity, TKey>
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ExistsByIdAsync](method-existsbyidasync-18.md) | Exists if an entity exists by id or not. Use it with the surrounding package APIs when composing application code. |
| [FindByIdAsync](method-findbyidasync-11.md) | Runs the `FindByIdAsync` operation on `ILookupByIdRepository<TEntity, TKey>`. Use it when your code needs this specific behavior from the package. |

