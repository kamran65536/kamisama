# InitializeAsync

[Back to DatabaseInitializerBase<TDbContext>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs:35](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/Initialization/DatabaseInitializerBase.cs#L35)

Type: `KamiSama.Repositories.EntityFrameworkCore.Initialization.DatabaseInitializerBase<TDbContext>`

Kind: `Method`

## Description

Runs the `InitializeAsync` operation on `DatabaseInitializerBase<TDbContext>`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async virtual Task InitializeAsync(DataInitializationOptions options, CancellationToken cancellationToken);
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

