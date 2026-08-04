# MigrateAsync

[Back to DatabaseInitializerBase<TDbContext>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs:20](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs#L20)

Type: `KamiSama.Repositories.EntityFrameworkCore.Initialization.DatabaseInitializerBase<TDbContext>`

Kind: `Method`

## Description

Migrates database to the latest version. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected virtual Task MigrateAsync(CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Remarks

This method is ONLY supported for relational database.

## Example

No concise standalone example is available yet.

