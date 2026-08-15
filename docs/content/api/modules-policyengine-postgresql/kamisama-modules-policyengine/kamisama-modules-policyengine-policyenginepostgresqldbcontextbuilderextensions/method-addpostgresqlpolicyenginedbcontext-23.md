# AddPostgresqlPolicyEngineDbContext

[Back to PolicyEnginePostgresqlDbContextBuilderExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Postgresql](../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Postgresql/PolicyEnginePostgresqlDbContextBuilderExtensions.cs:23](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Postgresql/PolicyEnginePostgresqlDbContextBuilderExtensions.cs#L23)

Type: `KamiSama.Modules.PolicyEngine.PolicyEnginePostgresqlDbContextBuilderExtensions`

Kind: `Method`

## Description

Registers `PostgresqlPolicyEngineDbContext` and its exact `postgresql` keyed `PolicyEngineDbContext` alias with lazy-loading proxies, the PolicyEngine migration-history table, and shared process-wide Npgsql compatibility switches. The provider currently has no PolicyEngine migrations.

## Declaration

```csharp
public static IMultiProviderDbContextBuilder<PolicyEngineDbContext> AddPostgresqlPolicyEngineDbContext(this IMultiProviderDbContextBuilder<PolicyEngineDbContext> builder);
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

Registration enables lazy-loading proxies and the shared PostgreSQL compatibility switches. This provider package currently contains no PolicyEngine migrations, so `MigrateAsync` cannot create the PolicyEngine schema.

## Example

No concise standalone example is available yet.

