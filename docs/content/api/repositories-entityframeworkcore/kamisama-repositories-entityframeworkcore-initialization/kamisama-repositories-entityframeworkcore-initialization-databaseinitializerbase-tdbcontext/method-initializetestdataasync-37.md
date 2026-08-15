# InitializeTestDataAsync

[Back to DatabaseInitializerBase<TDbContext>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs:37](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs#L37)

Type: `KamiSama.Repositories.EntityFrameworkCore.Initialization.DatabaseInitializerBase<TDbContext>`

Kind: `Method`

## Description

Creates test data when selected by the initialization options. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected abstract Task InitializeTestDataAsync(CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel test-data initialization. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that represents test-data initialization. |

## Example

```csharp
protected override Task InitializeTestDataAsync(CancellationToken cancellationToken)
    => SeedTestDataAsync(cancellationToken);
```

