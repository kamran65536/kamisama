# AddAsync

[Back to XmlDirectoryRepository<TEntity>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Xml](../../index.md)

Source: [src/Repositories.Xml/XmlDirectoryRepository.cs:159](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Xml/XmlDirectoryRepository.cs#L159)

Type: `KamiSama.Repositories.Xml.XmlDirectoryRepository<TEntity>`

Kind: `Method`

## Description

Runs the `AddAsync` operation on `XmlDirectoryRepository<TEntity>`. Use it when your code needs this specific behavior from the package.

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

