# InitializeDataAsync

[Back to DatabaseInitializerBase<TDbContext>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs:31](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs#L31)

Type: `KamiSama.Repositories.EntityFrameworkCore.Initialization.DatabaseInitializerBase<TDbContext>`

Kind: `Method`

## Description

Creates required application data when selected by the initialization options. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected abstract Task InitializeDataAsync(CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel application-data initialization. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that represents application-data initialization. |

## Example

```csharp
protected override Task InitializeDataAsync(CancellationToken cancellationToken)
    => SeedRequiredDataAsync(cancellationToken);
```

