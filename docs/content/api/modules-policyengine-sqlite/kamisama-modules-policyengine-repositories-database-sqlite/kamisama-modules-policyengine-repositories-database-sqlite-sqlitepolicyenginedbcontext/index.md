# SqlitePolicyEngineDbContext

<a id="sqlitepolicyenginedbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Sqlite](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Sqlite/Repositories/Database/Sqlite/SqlitePolicyEngineDbContext.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Sqlite/Repositories/Database/Sqlite/SqlitePolicyEngineDbContext.cs#L13)

Namespace: `KamiSama.Modules.PolicyEngine.Repositories.Database.Sqlite`

Kind: `Class`

## Description

Concrete SQLite PolicyEngine context registered through `AddSqlitePolicyEngineDbContext`. Its provider package currently contains no migrations.

## Declaration

```csharp
public class SqlitePolicyEngineDbContext(DbContextOptions<SqlitePolicyEngineDbContext> options) : PolicyEngineDbContext(options)
```

## Remarks

The provider package currently supplies no migrations for this context; applications must provision a compatible schema separately before using the CRUD features.

## Example

```csharp
ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddPolicyEngineModule(
    policySection, databaseSection, database => database.AddSqlitePolicyEngineDbContext());
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Sqlite/Repositories/Database/Sqlite/SqlitePolicyEngineDbContext.cs#L13)

Provides the concrete SQLite EF Core context used by PolicyEngine repositories. Use it with the surrounding package APIs when composing application code.

```csharp
public class SqlitePolicyEngineDbContext(DbContextOptions<SqlitePolicyEngineDbContext> options) : PolicyEngineDbContext(options)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions<SqlitePolicyEngineDbContext>` | `-` | The SQLite options configured by `AddSqlitePolicyEngineDbContext`. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

