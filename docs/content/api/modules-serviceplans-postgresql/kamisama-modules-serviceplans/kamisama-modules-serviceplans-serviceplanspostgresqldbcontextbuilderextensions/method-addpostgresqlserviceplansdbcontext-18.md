# AddPostgresqlServicePlansDbContext

[Back to ServicePlansPostgresqlDbContextBuilderExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Postgresql](../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Postgresql/ServicePlansPostgresqlDbContextBuilderExtensions.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Postgresql/ServicePlansPostgresqlDbContextBuilderExtensions.cs#L18)

Type: `KamiSama.Modules.ServicePlans.ServicePlansPostgresqlDbContextBuilderExtensions`

Kind: `Method`

## Description

Registers `PostgresqlServicePlansDbContext` and its exact `postgresql` keyed `ServicePlansDbContext` alias with lazy-loading proxies, the ServicePlans migration-history table, and shared process-wide Npgsql compatibility switches. The provider has no ServicePlans migrations.

## Declaration

```csharp
public static IMultiProviderDbContextBuilder<ServicePlansDbContext> AddPostgresqlServicePlansDbContext(this IMultiProviderDbContextBuilder<ServicePlansDbContext> builder);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `IMultiProviderDbContextBuilder<ServicePlansDbContext>` | `-` | The ServicePlans multi-provider context builder. |

## Returns

| Type | Description |
| --- | --- |
| `IMultiProviderDbContextBuilder<ServicePlansDbContext>` | The same builder for fluent provider configuration. |

## Example

```csharp
database.AddPostgresqlServicePlansDbContext(); // Registers the exact postgresql provider key.
```

