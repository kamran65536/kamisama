# WithMigrationHistoryTable

[Back to IMultiProviderDbContextBuilder<TBaseContext>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Repositories.EntityFrameworkCore](../../index.md)

Source: [src/Repositories.EntityFrameworkCore/IMultiProviderDbContextBuilder.cs:51](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Repositories.EntityFrameworkCore/IMultiProviderDbContextBuilder.cs#L51)

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
| `migrationHistoryTable` | `string` | `-` | The exact migrations history table name passed to each provider registration. |

## Returns

| Type | Description |
| --- | --- |
| `IMultiProviderDbContextBuilder<TBaseContext>` | The same builder, enabling provider registration chaining. |

## Example

```csharp
builder.WithMigrationHistoryTable("__AppMigrationsHistory");
```

