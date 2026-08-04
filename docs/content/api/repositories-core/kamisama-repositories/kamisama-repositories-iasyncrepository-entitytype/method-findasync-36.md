# FindAsync

[Back to IAsyncRepository<_EntityType>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/IAsyncRepository.cs:36](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/IAsyncRepository.cs#L36)

Type: `KamiSama.Repositories.IAsyncRepository<_EntityType>`

Kind: `Method`

## Description

Finds an item in the repository. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<_EntityType?> FindAsync(Expression<Func<_EntityType, bool>> predicate, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `predicate` | `Expression<Func<_EntityType, bool>>` | `-` | The `predicate` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<_EntityType?>` | Returns a `Task<_EntityType?>` value. |

## Example

```csharp
var entity = new SampleEntity { Id = 1, Name = "Test" };
var context = GetDbContext(initialDbSet: [entity]);
var repository = new DbRepository<SampleEntity>(context);

var result = await repository.FindAsync(x => x.Id == 1, CancellationToken.None);

var result2 = await repository.FindAsync(x => x.Id == 2, CancellationToken.None);
```

