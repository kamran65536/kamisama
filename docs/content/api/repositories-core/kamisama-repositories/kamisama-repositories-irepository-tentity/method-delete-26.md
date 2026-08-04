# Delete

[Back to IRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/IRepository.cs:26](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/IRepository.cs#L26)

Type: `KamiSama.Repositories.IRepository<TEntity>`

Kind: `Method`

## Description

Deletes an item from repository. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
void Delete(TEntity item);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `TEntity` | `-` | The `item` value passed to this member. |

## Example

```csharp
var entity = new SampleEntity { Id = 1, Name = "Test" };
var context = GetDbContext(initialDbSet: [entity]);

var repository = new DbRepository<SampleEntity>(context);

repository.Delete(entity);
```

