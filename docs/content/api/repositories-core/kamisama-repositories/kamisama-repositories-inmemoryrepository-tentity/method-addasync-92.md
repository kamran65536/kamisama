# AddAsync

[Back to InMemoryRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/InMemoryRepository.cs:92](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/InMemoryRepository.cs#L92)

Type: `KamiSama.Repositories.InMemoryRepository<TEntity>`

Kind: `Method`

## Description

Runs the `AddAsync` operation on `InMemoryRepository<TEntity>`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public virtual async Task AddAsync(TEntity item, CancellationToken cancellationToken);
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

