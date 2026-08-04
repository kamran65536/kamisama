# MigrationHistoryTable

[Back to MultiProviderDbContextBuilder<TBaseContext>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/MultiProviderDbContextBuilder.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/MultiProviderDbContextBuilder.cs#L16)

Type: `KamiSama.Repositories.EntityFrameworkCore.MultiProviderDbContextBuilder<TBaseContext>`

Kind: `Property`

## Description

Exposes the `MigrationHistoryTable` value on `MultiProviderDbContextBuilder<TBaseContext>`. Read or set it as part of configuring or using the type.

## Declaration

```csharp
public string MigrationHistoryTable { get; set; } = $"{typeof(TBaseContext).Name}_History";
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets or sets a `string` value. |

## Example

No concise standalone example is available yet.

