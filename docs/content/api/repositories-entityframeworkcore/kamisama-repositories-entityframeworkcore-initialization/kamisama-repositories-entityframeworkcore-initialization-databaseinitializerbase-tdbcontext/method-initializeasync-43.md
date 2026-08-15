# InitializeAsync

[Back to DatabaseInitializerBase<TDbContext>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs:43](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs#L43)

Type: `KamiSama.Repositories.EntityFrameworkCore.Initialization.DatabaseInitializerBase<TDbContext>`

Kind: `Method`

## Description

Runs each migration or seed stage enabled by the supplied options. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public async virtual Task InitializeAsync(DataInitializationOptions options, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DataInitializationOptions` | `-` | The stages to run. |
| `cancellationToken` | `CancellationToken` | `-` | A token passed to every selected stage. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that completes after all selected stages finish. |

## Remarks

Stages are not wrapped in a transaction by this base class and stop at the first failure.

## Example

```csharp
await initializer.InitializeAsync(options, cancellationToken);
```

