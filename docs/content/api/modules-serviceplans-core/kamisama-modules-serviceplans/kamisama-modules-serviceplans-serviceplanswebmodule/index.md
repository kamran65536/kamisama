# ServicePlansWebModule

<a id="serviceplanswebmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.ServicePlans.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.ServicePlans.Core/ServicePlansWebModule.cs:23](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Core/ServicePlansWebModule.cs#L23)

Namespace: `KamiSama.Modules.ServicePlans`

Kind: `Class`

## Description

Registers ServicePlans options, assignable scoped features and repositories, keyed provider setup, and named post-build initialization. It maps no transport or security layer, and current providers contain no ServicePlans migrations.

## Declaration

```csharp
public class ServicePlansWebModule(
	IConfigurationSection moduleSection,
	IConfigurationSection databaseSection,
	Action<IMultiProviderDbContextBuilder<ServicePlansDbContext>>? configureDbContext = null) : WebModule
```

## Example

```csharp
var module = new ServicePlansWebModule(
    servicePlansSection, databaseSection,
    database => database.AddPostgresqlServicePlansDbContext());
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.ServicePlans.Core/ServicePlansWebModule.cs#L23)

Registers ServicePlans options, scoped repositories and features, a keyed EF Core provider, and post-build database initialization. The module does not map controllers, endpoints, middleware, authentication, or authorization.

```csharp
public class ServicePlansWebModule(
	IConfigurationSection moduleSection,
	IConfigurationSection databaseSection,
	Action<IMultiProviderDbContextBuilder<ServicePlansDbContext>>? configureDbContext = null) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `moduleSection` | `IConfigurationSection` | `-` | The ServicePlans configuration section containing `options` and `initialization` children. |
| `databaseSection` | `IConfigurationSection` | `-` | The database section containing the provider key and connection string. |
| `configureDbContext` | `Action<IMultiProviderDbContextBuilder<ServicePlansDbContext>>?` | `null` | The callback that registers installed concrete provider contexts; it is required in a normal host. |

## Members

### Fields

| Member | Description |
| --- | --- |
| [ModuleName](field-modulename-31.md) | Identifies the named database and initialization options used by this module. Use it with the surrounding package APIs when composing application code. |

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-56.md) | Resolves a custom or migration-only database initializer and executes the enabled initialization stages after build. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-37.md) | Binds module and named database options, discovers attributed Core services, and invokes the provider callback. Use it with the surrounding package APIs when composing application code. |

