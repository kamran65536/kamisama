# SqliteServicePlansDbContext

<a id="sqliteserviceplansdbcontext"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Sqlite](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Sqlite/Repositories/Database/Sqlite/SqliteServicePlansDbContext.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Sqlite/Repositories/Database/Sqlite/SqliteServicePlansDbContext.cs#L11)

Namespace: `KamiSama.Modules.ServicePlans.Repositories.Database.Sqlite`

Kind: `Class`

## Description

Concrete SQLite ServicePlans context registered through `AddSqliteServicePlansDbContext`. Its provider package currently contains no migrations.

## Declaration

```csharp
public class SqliteServicePlansDbContext(DbContextOptions<SqliteServicePlansDbContext> options) : ServicePlansDbContext(options)
```

## Example

```csharp
ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddServicePlansModule(
    servicePlansSection, databaseSection,
    database => database.AddSqliteServicePlansDbContext());
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Sqlite/Repositories/Database/Sqlite/SqliteServicePlansDbContext.cs#L11)

Provides the concrete SQLite context registered for the ServicePlans `sqlite` provider key. This provider package currently contains no ServicePlans migrations.

```csharp
public class SqliteServicePlansDbContext(DbContextOptions<SqliteServicePlansDbContext> options) : ServicePlansDbContext(options)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `DbContextOptions<SqliteServicePlansDbContext>` | `-` | The SQLite-configured EF Core options. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

