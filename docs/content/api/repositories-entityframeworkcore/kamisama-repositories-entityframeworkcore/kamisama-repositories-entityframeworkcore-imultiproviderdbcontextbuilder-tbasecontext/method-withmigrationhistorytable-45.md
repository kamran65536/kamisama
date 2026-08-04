# WithMigrationHistoryTable

[Back to IMultiProviderDbContextBuilder<TBaseContext>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/IMultiProviderDbContextBuilder.cs:45](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/IMultiProviderDbContextBuilder.cs#L45)

Type: `KamiSama.Repositories.EntityFrameworkCore.IMultiProviderDbContextBuilder<TBaseContext>`

Kind: `Method`

## Description

Sets the EF Core migrations history table used by provider registrations. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
IMultiProviderDbContextBuilder<TBaseContext> WithMigrationHistoryTable(string migrationHistoryTable);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `migrationHistoryTable` | `string` | `-` | The migrations history table name. |

## Returns

| Type | Description |
| --- | --- |
| `IMultiProviderDbContextBuilder<TBaseContext>` | The current builder. |

## Example

No concise standalone example is available yet.

