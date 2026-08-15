# ServicePlansSqliteDbContextBuilderExtensions

<a id="serviceplanssqlitedbcontextbuilderextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Sqlite](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Sqlite/ServicePlansSqliteDbContextBuilderExtensions.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Sqlite/ServicePlansSqliteDbContextBuilderExtensions.cs#L11)

Namespace: `KamiSama.Modules.ServicePlans`

Kind: `Class`

## Description

Registers the SQLite ServicePlans context under the exact `sqlite` keyed base-context service. It enables lazy loading but supplies no migrations.

## Declaration

```csharp
public static class ServicePlansSqliteDbContextBuilderExtensions
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddSqliteServicePlansDbContext](method-addsqliteserviceplansdbcontext-18.md) | Registers `SqliteServicePlansDbContext` and its exact `sqlite` keyed `ServicePlansDbContext` alias with lazy-loading proxies and the ServicePlans migration-history table. The provider has no ServicePlans migrations. |

