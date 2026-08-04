# InitializeTestDataAsync

[Back to DatabaseInitializerBase<TDbContext>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs:33](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs#L33)

Type: `KamiSama.Repositories.EntityFrameworkCore.Initialization.DatabaseInitializerBase<TDbContext>`

Kind: `Method`

## Description

Initialize test data for the database. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected abstract Task InitializeTestDataAsync(CancellationToken cancellationToken);
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

No concise standalone example is available yet.

