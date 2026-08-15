# IAddableRepository<TEntity>

<a id="iaddablerepository-tentity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Repositories/IAddableRepository.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Repositories/IAddableRepository.cs#L7)

Namespace: `KamiSama.Chassis.Commons.Repositories`

Kind: `Interface`

## Description

Defines persistence of new entities. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IAddableRepository<TEntity>
```

## Example

```csharp
await products.AddAsync(product, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddAsync](method-addasync-15.md) | Adds an entity to the underlying store. Use it with the surrounding package APIs when composing application code. |

