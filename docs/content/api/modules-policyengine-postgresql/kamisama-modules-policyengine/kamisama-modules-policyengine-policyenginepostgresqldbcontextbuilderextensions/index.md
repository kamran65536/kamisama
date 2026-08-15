# PolicyEnginePostgresqlDbContextBuilderExtensions

<a id="policyenginepostgresqldbcontextbuilderextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Postgresql](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Postgresql/PolicyEnginePostgresqlDbContextBuilderExtensions.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Postgresql/PolicyEnginePostgresqlDbContextBuilderExtensions.cs#L11)

Namespace: `KamiSama.Modules.PolicyEngine`

Kind: `Class`

## Description

Registers the PostgreSQL PolicyEngine context under the exact `postgresql` keyed base-context service. It enables lazy loading and shared Npgsql switches but supplies no migrations.

## Declaration

```csharp
public static class PolicyEnginePostgresqlDbContextBuilderExtensions
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddPostgresqlPolicyEngineDbContext](method-addpostgresqlpolicyenginedbcontext-23.md) | Registers `PostgresqlPolicyEngineDbContext` and its exact `postgresql` keyed `PolicyEngineDbContext` alias with lazy-loading proxies, the PolicyEngine migration-history table, and shared process-wide Npgsql compatibility switches. The provider currently has no PolicyEngine migrations. |

