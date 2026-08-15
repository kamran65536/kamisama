# AddSqlitePolicyEngineDbContext

[Back to PolicyEngineSqliteDbContextBuilderExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Sqlite](../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Sqlite/PolicyEngineSqliteDbContextBuilderExtensions.cs:23](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Sqlite/PolicyEngineSqliteDbContextBuilderExtensions.cs#L23)

Type: `KamiSama.Modules.PolicyEngine.PolicyEngineSqliteDbContextBuilderExtensions`

Kind: `Method`

## Description

Registers `SqlitePolicyEngineDbContext` and its exact `sqlite` keyed `PolicyEngineDbContext` alias with lazy-loading proxies and the PolicyEngine migration-history table. The provider currently has no PolicyEngine migrations.

## Declaration

```csharp
public static IMultiProviderDbContextBuilder<PolicyEngineDbContext> AddSqlitePolicyEngineDbContext(this IMultiProviderDbContextBuilder<PolicyEngineDbContext> builder);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `IMultiProviderDbContextBuilder<PolicyEngineDbContext>` | `-` | The PolicyEngine multi-provider builder carrying services, connection settings, and migration-history table. |

## Returns

| Type | Description |
| --- | --- |
| `IMultiProviderDbContextBuilder<PolicyEngineDbContext>` | The same builder so provider setup can be chained. |

## Remarks

Registration enables lazy-loading proxies. This provider package currently contains no PolicyEngine migrations, so `MigrateAsync` cannot create the PolicyEngine schema.

## Example

No concise standalone example is available yet.

