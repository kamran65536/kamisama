# InitializeTestDataAsync

[Back to DefaultDatabaseInitializer<TDbContext>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/Initialization/DefaultDatabaseInitializer.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/Initialization/DefaultDatabaseInitializer.cs#L17)

Type: `KamiSama.Repositories.EntityFrameworkCore.Initialization.DefaultDatabaseInitializer<TDbContext>`

Kind: `Method`

## Description

Runs the `InitializeTestDataAsync` operation on `DefaultDatabaseInitializer<TDbContext>`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
protected override Task InitializeTestDataAsync(CancellationToken cancellationToken);
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

