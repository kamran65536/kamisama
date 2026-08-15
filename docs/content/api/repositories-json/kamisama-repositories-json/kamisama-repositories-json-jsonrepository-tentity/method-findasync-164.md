# FindAsync

[Back to JsonRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Json](../../index.md)

Source: [src/Repositories.Json/JsonRepository.cs:164](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Json/JsonRepository.cs#L164)

Type: `KamiSama.Repositories.Json.JsonRepository<TEntity>`

Kind: `Method`

## Description

Loads on demand and returns the first matching cached entity, or the default value after a load failure, a null predicate, or no match.

## Declaration

```csharp
public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>>? predicate, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>?` | `-` | The predicate to compile and apply, or to return the default value. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel loading. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntity?>` | The first matching entity, or the default value when loading fails, the predicate is , or no entity matches. |

## Example

```csharp
using KamiSama.Repositories.Json;

var repository = new JsonRepository<User>("users.json");
var user = await repository.FindAsync(x => x.Id == 1, cancellationToken);
```

