# DeleteAsync

[Back to RestBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.RestSharp](../../index.md)

Source: [src/KamiSama.Extensions.RestSharp/RestBuilder.cs:106](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/RestBuilder.cs#L106)

Type: `KamiSama.Extensions.RestSharp.RestBuilder`

Kind: `Method`

## Description

Runs the `DeleteAsync` operation on `RestBuilder`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task DeleteAsync(CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

```csharp
var entity = new SampleEntity { Id = 1, Name = "Test" };
var context = GetDbContext(initialDbSet: [entity]);

var repository = new DbRepository<SampleEntity>(context);

await repository.DeleteAsync(entity, CancellationToken.None);
```

