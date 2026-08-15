# AddSqliteIdentityDbContext

[Back to IdentitySqliteDbContextBuilderExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Sqlite](../../index.md)

Source: [src/KamiSama.Modules.Identity.Sqlite/IdentitySqliteDbContextBuilderExtensions.cs:14](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Sqlite/IdentitySqliteDbContextBuilderExtensions.cs#L14)

Type: `KamiSama.Modules.Identity.IdentitySqliteDbContextBuilderExtensions`

Kind: `Method`

## Description

Registers the SQLite Identity context under the provider key used by the shared multi-provider infrastructure. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static IMultiProviderDbContextBuilder<KamiSamaIdentityDbContext> AddSqliteIdentityDbContext(this IMultiProviderDbContextBuilder<KamiSamaIdentityDbContext> builder);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `IMultiProviderDbContextBuilder<KamiSamaIdentityDbContext>` | `-` | The Identity context builder returned by the Core module. |

## Returns

| Type | Description |
| --- | --- |
| `IMultiProviderDbContextBuilder<KamiSamaIdentityDbContext>` | The same builder for fluent configuration. |

## Example

```csharp
builder.AddSqliteIdentityDbContext(); // Registers the exact sqlite provider key.
```

