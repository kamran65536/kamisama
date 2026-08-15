# PolicyEngineSqliteDbContextBuilderExtensions

<a id="policyenginesqlitedbcontextbuilderextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Sqlite](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Sqlite/PolicyEngineSqliteDbContextBuilderExtensions.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Sqlite/PolicyEngineSqliteDbContextBuilderExtensions.cs#L11)

Namespace: `KamiSama.Modules.PolicyEngine`

Kind: `Class`

## Description

Registers the SQLite PolicyEngine context under the exact `sqlite` keyed base-context service. It enables lazy loading but supplies no migrations.

## Declaration

```csharp
public static class PolicyEngineSqliteDbContextBuilderExtensions
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddSqlitePolicyEngineDbContext](method-addsqlitepolicyenginedbcontext-23.md) | Registers `SqlitePolicyEngineDbContext` and its exact `sqlite` keyed `PolicyEngineDbContext` alias with lazy-loading proxies and the PolicyEngine migration-history table. The provider currently has no PolicyEngine migrations. |

