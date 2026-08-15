# ServicePlansPostgresqlDbContextBuilderExtensions

<a id="serviceplanspostgresqldbcontextbuilderextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Postgresql](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Postgresql/ServicePlansPostgresqlDbContextBuilderExtensions.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Postgresql/ServicePlansPostgresqlDbContextBuilderExtensions.cs#L11)

Namespace: `KamiSama.Modules.ServicePlans`

Kind: `Class`

## Description

Registers the PostgreSQL ServicePlans context under the exact `postgresql` keyed base-context service. It enables lazy loading and shared Npgsql switches but supplies no migrations.

## Declaration

```csharp
public static class ServicePlansPostgresqlDbContextBuilderExtensions
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddPostgresqlServicePlansDbContext](method-addpostgresqlserviceplansdbcontext-18.md) | Registers `PostgresqlServicePlansDbContext` and its exact `postgresql` keyed `ServicePlansDbContext` alias with lazy-loading proxies, the ServicePlans migration-history table, and shared process-wide Npgsql compatibility switches. The provider has no ServicePlans migrations. |

