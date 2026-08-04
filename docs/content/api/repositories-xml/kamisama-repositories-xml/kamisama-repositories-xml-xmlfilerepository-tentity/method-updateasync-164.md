# UpdateAsync

[Back to XmlFileRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Xml](../../index.md)

Source: [src/Repositories.Xml/XmlFileRepository.cs:164](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlFileRepository.cs#L164)

Type: `KamiSama.Repositories.Xml.XmlFileRepository<TEntity>`

Kind: `Method`

## Description

Runs the `UpdateAsync` operation on `XmlFileRepository<TEntity>`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public Task UpdateAsync(TEntity? item, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `item` | `TEntity?` | `-` | The `item` value passed to this member. |
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

