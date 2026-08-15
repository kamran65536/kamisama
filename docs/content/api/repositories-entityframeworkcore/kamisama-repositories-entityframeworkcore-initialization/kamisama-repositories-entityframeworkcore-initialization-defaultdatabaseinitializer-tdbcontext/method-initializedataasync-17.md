# InitializeDataAsync

[Back to DefaultDatabaseInitializer<TDbContext>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/Initialization/DefaultDatabaseInitializer.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/Initialization/DefaultDatabaseInitializer.cs#L17)

Type: `KamiSama.Repositories.EntityFrameworkCore.Initialization.DefaultDatabaseInitializer<TDbContext>`

Kind: `Method`

## Description

Completes without creating application data. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected override Task InitializeDataAsync(CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cancellationToken` | `CancellationToken` | `-` | Unused because this implementation performs no work. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A completed task. |

## Example

```csharp
// DefaultDatabaseInitializer completes this selected stage without creating data.
await initializer.InitializeAsync(options, cancellationToken);
```

