# InitializeAsync

[Back to IDatabaseInitializer<TDbContext>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/Initialization/IDatabaseInitializer.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/Initialization/IDatabaseInitializer.cs#L18)

Type: `KamiSama.Repositories.Initialization.IDatabaseInitializer<TDbContext>`

Kind: `Method`

## Description

Runs the migration and seed stages selected by `DataInitializationOptions`; the implementation owns ordering, idempotency, persistence, and failure behavior.

## Declaration

```csharp
Task InitializeAsync(DataInitializationOptions options, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DataInitializationOptions` | `-` | The stages the initializer should run. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel initialization. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that represents database initialization. |

## Example

```csharp
await initializer.InitializeAsync(options, cancellationToken);
```

