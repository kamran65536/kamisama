# PostgresqlPolicyEngineDbContext

<a id="postgresqlpolicyenginedbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.PolicyEngine.Postgresql](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.PolicyEngine.Postgresql/Repositories/Database/Postgresql/PostgresqlPolicyEngineDbContext.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Postgresql/Repositories/Database/Postgresql/PostgresqlPolicyEngineDbContext.cs#L13)

Namespace: `KamiSama.Modules.PolicyEngine.Repositories.Database.Postgresql`

Kind: `Class`

## Description

Concrete PostgreSQL PolicyEngine context registered through `AddPostgresqlPolicyEngineDbContext`. Its provider package currently contains no migrations.

## Declaration

```csharp
public class PostgresqlPolicyEngineDbContext(DbContextOptions<PostgresqlPolicyEngineDbContext> options) : PolicyEngineDbContext(options)
```

## Remarks

The provider package currently supplies no migrations for this context; applications must provision a compatible schema separately before using the CRUD features.

## Example

```csharp
ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddPolicyEngineModule(
    policySection, databaseSection, database => database.AddPostgresqlPolicyEngineDbContext());
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.PolicyEngine.Postgresql/Repositories/Database/Postgresql/PostgresqlPolicyEngineDbContext.cs#L13)

Provides the concrete PostgreSQL EF Core context used by PolicyEngine repositories. Use it with the surrounding package APIs when composing application code.

```csharp
public class PostgresqlPolicyEngineDbContext(DbContextOptions<PostgresqlPolicyEngineDbContext> options) : PolicyEngineDbContext(options)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions<PostgresqlPolicyEngineDbContext>` | `-` | The PostgreSQL options configured by `AddPostgresqlPolicyEngineDbContext`. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

