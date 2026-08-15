# MigrateAsync

[Back to DatabaseInitializerBase<TDbContext>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs:24](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs#L24)

Type: `KamiSama.Repositories.EntityFrameworkCore.Initialization.DatabaseInitializerBase<TDbContext>`

Kind: `Method`

## Description

Applies all pending EF Core migrations. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected virtual Task MigrateAsync(CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel migration. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that represents migration. |

## Remarks

This method is supported only by relational providers.

## Example

```csharp
await MigrateAsync(cancellationToken); // Available to a derived initializer.
```

