# AddAsync

[Back to JsonRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Json](../../index.md)

Source: [src/Repositories.Json/JsonRepository.cs:133](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Json/JsonRepository.cs#L133)

Type: `KamiSama.Repositories.Json.JsonRepository<TEntity>`

Kind: `Method`

## Description

Runs the `AddAsync` operation on `JsonRepository<TEntity>`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public Task AddAsync(TEntity item, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `TEntity` | `-` | The `item` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

```csharp
var sample = new SampleEntity { Id = 1, Name = "sample" };
var repository = new InMemoryRepository<SampleEntity>();

await repository.AddAsync(sample, CancellationToken.None);
```

