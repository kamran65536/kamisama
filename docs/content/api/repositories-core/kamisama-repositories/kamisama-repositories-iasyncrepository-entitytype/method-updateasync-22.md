# UpdateAsync

[Back to IAsyncRepository<_EntityType>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/IAsyncRepository.cs:22](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/IAsyncRepository.cs#L22)

Type: `KamiSama.Repositories.IAsyncRepository<_EntityType>`

Kind: `Method`

## Description

Updates an item in the repository. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task UpdateAsync(_EntityType item, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `_EntityType` | `-` | The `item` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

```csharp
var sample = new SampleEntity { Id = 1, Name = "sample" };
var repository = new InMemoryRepository<SampleEntity>([sample]);

sample.Name = "sample2";

await repository.UpdateAsync(sample, CancellationToken.None);

var retrieved = repository.Find(x => x.Name == "sample2");
```

