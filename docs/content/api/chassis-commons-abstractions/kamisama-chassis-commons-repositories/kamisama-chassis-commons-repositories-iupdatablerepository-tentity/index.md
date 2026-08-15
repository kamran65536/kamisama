# IUpdatableRepository<TEntity>

<a id="iupdatablerepository-tentity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Repositories/IUpdatableRepository.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Repositories/IUpdatableRepository.cs#L7)

Namespace: `KamiSama.Chassis.Commons.Repositories`

Kind: `Interface`

## Description

Defines persistence of changes to existing entities. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IUpdatableRepository<TEntity>
```

## Example

```csharp
product.Name = "Mechanical Keyboard";
await products.UpdateAsync(product, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [UpdateAsync](method-updateasync-15.md) | Updates an entity in the underlying store. Use it with the surrounding package APIs when composing application code. |

