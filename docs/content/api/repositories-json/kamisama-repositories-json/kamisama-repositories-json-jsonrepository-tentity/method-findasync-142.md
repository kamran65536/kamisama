# FindAsync

[Back to JsonRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Json](../../index.md)

Source: [src/Repositories.Json/JsonRepository.cs:142](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Json/JsonRepository.cs#L142)

Type: `KamiSama.Repositories.Json.JsonRepository<TEntity>`

Kind: `Method`

## Description

Runs the `FindAsync` operation on `JsonRepository<TEntity>`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>>? predicate, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<TEntity, bool>>?` | `-` | The `predicate` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TEntity?>` | Returns a `Task<TEntity?>` value. |

## Example

```csharp
using KamiSama.Repositories.Json;

var repository = new JsonRepository<User>("users.json");
var user = await repository.FindAsync(x => x.Id == 1, cancellationToken);
```

