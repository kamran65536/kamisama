# InitializeAsync

[Back to IDatabaseInitializer<TDbContext>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.Core](../../index.md)

Source: [src/Repositories.Core/Initialization/IDatabaseInitializer.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.Core/Initialization/IDatabaseInitializer.cs#L18)

Type: `KamiSama.Repositories.Initialization.IDatabaseInitializer<TDbContext>`

Kind: `Method`

## Description

Initialize and migrates the database if necessary. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task InitializeAsync(DataInitializationOptions options, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DataInitializationOptions` | `-` | The `options` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

