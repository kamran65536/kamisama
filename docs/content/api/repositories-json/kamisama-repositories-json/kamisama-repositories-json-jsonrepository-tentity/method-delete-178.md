# Delete

[Back to JsonRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Json](../../index.md)

Source: [src/Repositories.Json/JsonRepository.cs:178](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Json/JsonRepository.cs#L178)

Type: `KamiSama.Repositories.Json.JsonRepository<TEntity>`

Kind: `Method`

## Description

Deletes an item from repository; Modify to json repository is not recommended for performance issues. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public void Delete(TEntity item);
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

