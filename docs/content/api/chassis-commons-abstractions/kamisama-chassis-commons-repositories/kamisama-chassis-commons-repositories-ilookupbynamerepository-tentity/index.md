# ILookupByNameRepository<TEntity>

<a id="ilookupbynamerepository-tentity"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Commons.Abstractions/Repositories/ILookupByNameRepository.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Repositories/ILookupByNameRepository.cs#L7)

Namespace: `KamiSama.Chassis.Commons.Repositories`

Kind: `Interface`

## Description

Defines lookup and existence checks by entity name. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface ILookupByNameRepository<TEntity>
```

## Example

```csharp
Product? product = await products.FindByNameAsync("Keyboard", cancellationToken);
bool exists = await products.ExistsByNameAsync("Keyboard", cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ExistsByNameAsync](method-existsbynameasync-22.md) | Determines whether an entity with the supplied name exists. Use it with the surrounding package APIs when composing application code. |
| [FindByNameAsync](method-findbynameasync-15.md) | Runs the `FindByNameAsync` operation on `ILookupByNameRepository<TEntity>`. Use it when your code needs this specific behavior from the package. |

