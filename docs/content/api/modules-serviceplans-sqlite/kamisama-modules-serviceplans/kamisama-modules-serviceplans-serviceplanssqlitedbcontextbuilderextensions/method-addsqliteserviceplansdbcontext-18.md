# AddSqliteServicePlansDbContext

[Back to ServicePlansSqliteDbContextBuilderExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Sqlite](../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Sqlite/ServicePlansSqliteDbContextBuilderExtensions.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Sqlite/ServicePlansSqliteDbContextBuilderExtensions.cs#L18)

Type: `KamiSama.Modules.ServicePlans.ServicePlansSqliteDbContextBuilderExtensions`

Kind: `Method`

## Description

Registers `SqliteServicePlansDbContext` and its exact `sqlite` keyed `ServicePlansDbContext` alias with lazy-loading proxies and the ServicePlans migration-history table. The provider has no ServicePlans migrations.

## Declaration

```csharp
public static IMultiProviderDbContextBuilder<ServicePlansDbContext> AddSqliteServicePlansDbContext(this IMultiProviderDbContextBuilder<ServicePlansDbContext> builder);
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
database.AddSqliteServicePlansDbContext(); // Registers the exact sqlite provider key.
```

