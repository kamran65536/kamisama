# AddServicePlansModule

[Back to ExtendedWebApplicationBuilderExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Core](../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Core/ServicePlansWebModule.cs:80](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Core/ServicePlansWebModule.cs#L80)

Type: `KamiSama.Modules.ServicePlans.ExtendedWebApplicationBuilderExtensions`

Kind: `Method`

## Description

Queues ServicePlans service discovery, keyed provider setup, and post-build initialization. The callback must register the lowercased configured provider key; current provider packages contain no migrations, so `BuildAsync` cannot create the schema from this checkout.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddServicePlansModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection moduleSection, IConfigurationSection databaseSection, Action<IMultiProviderDbContextBuilder<ServicePlansDbContext>>? configureDbContext = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The extended builder that receives the module. |
| `moduleSection` | `IConfigurationSection` | `-` | The ServicePlans configuration section. |
| `databaseSection` | `IConfigurationSection` | `-` | The database provider and connection-string section. |
| `configureDbContext` | `Action<IMultiProviderDbContextBuilder<ServicePlansDbContext>>?` | `null` | The callback that registers the selected provider context; normal setup requires it. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | The same extended builder for fluent module composition. |

## Example

```csharp
ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddServicePlansModule(
    servicePlansSection, databaseSection,
    database => database.AddPostgresqlServicePlansDbContext());
WebApplication app = await builder.BuildAsync(cancellationToken);
```

