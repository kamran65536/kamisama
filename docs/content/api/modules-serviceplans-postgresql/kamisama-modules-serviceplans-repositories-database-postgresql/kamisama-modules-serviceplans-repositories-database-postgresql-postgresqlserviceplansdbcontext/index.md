# PostgresqlServicePlansDbContext

<a id="postgresqlserviceplansdbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Postgresql](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Postgresql/Repositories/Database/Postgresql/PostgresqlServicePlansDbContext.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Postgresql/Repositories/Database/Postgresql/PostgresqlServicePlansDbContext.cs#L11)

Namespace: `KamiSama.Modules.ServicePlans.Repositories.Database.Postgresql`

Kind: `Class`

## Description

Concrete PostgreSQL ServicePlans context registered through `AddPostgresqlServicePlansDbContext`. Its provider package currently contains no migrations.

## Declaration

```csharp
public class PostgresqlServicePlansDbContext(DbContextOptions<PostgresqlServicePlansDbContext> options) : ServicePlansDbContext(options)
```

## Example

```csharp
ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddServicePlansModule(
    servicePlansSection, databaseSection,
    database => database.AddPostgresqlServicePlansDbContext());
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Postgresql/Repositories/Database/Postgresql/PostgresqlServicePlansDbContext.cs#L11)

Provides the concrete Npgsql context registered for the ServicePlans `postgresql` provider key. This provider package currently contains no ServicePlans migrations.

```csharp
public class PostgresqlServicePlansDbContext(DbContextOptions<PostgresqlServicePlansDbContext> options) : ServicePlansDbContext(options)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions<PostgresqlServicePlansDbContext>` | `-` | The Npgsql-configured EF Core options. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

