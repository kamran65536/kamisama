# KamiSamaIdentityWebModule

<a id="kamisamaidentitywebmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/KamiSamaIdentityWebModule.cs:26](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/KamiSamaIdentityWebModule.cs#L26)

Namespace: `KamiSama.Modules.Identity`

Kind: `Class`

## Description

Registers Identity, authentication, scanned feature implementations, and a multi-provider DbContext, then performs configured database initialization after build. A concrete provider callback and correctly ordered authentication middleware are required in practice.

## Declaration

```csharp
public class KamiSamaIdentityWebModule(
	IConfigurationSection moduleSection,
	IConfigurationSection databaseSection,
	bool registerIdentity,
	bool useJwtAuth,
	Action<IMultiProviderDbContextBuilder<KamiSamaIdentityDbContext>>? configureDbContext = null) : WebModule
```

## Example

```csharp
var builder = webBuilder.Extend().AddModule(new KamiSamaIdentityWebModule(
    webBuilder.Configuration.GetSection("Identity"),
    webBuilder.Configuration.GetSection("Identity:Database"),
    registerIdentity: true,
    useJwtAuth: true,
    configureDbContext: database => database.AddPostgresqlIdentityDbContext()));
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/KamiSamaIdentityWebModule.cs#L26)

Registers Identity options, authentication, attributed feature implementations, and a multi-provider Identity DbContext, then runs configured database initialization after build. A provider callback is operationally required, and the host must place authentication middleware before authorization middleware.

```csharp
public class KamiSamaIdentityWebModule(
	IConfigurationSection moduleSection,
	IConfigurationSection databaseSection,
	bool registerIdentity,
	bool useJwtAuth,
	Action<IMultiProviderDbContextBuilder<KamiSamaIdentityDbContext>>? configureDbContext = null) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `moduleSection` | `IConfigurationSection` | `-` | The Identity section containing `options`, `jwt`, and `initialization` children. |
| `databaseSection` | `IConfigurationSection` | `-` | The database section containing `provider` and `connection-string`. |
| `registerIdentity` | `bool` | `-` | Whether to register ASP.NET Core Identity stores, managers, sign-in manager, and token providers. |
| `useJwtAuth` | `bool` | `-` | Whether to configure JWT bearer authentication instead of Identity application-scheme defaults. |
| `configureDbContext` | `Action<IMultiProviderDbContextBuilder<KamiSamaIdentityDbContext>>?` | `null` | The callback that must add an installed provider to the multi-provider context builder. |

## Members

### Fields

| Member | Description |
| --- | --- |
| [ModuleName](field-modulename-34.md) | Gets the name used for named options and migration-history configuration. Use it with the surrounding package APIs when composing application code. |

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-111.md) | Creates a startup scope and runs migration and seed stages selected by the named initialization options. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-41.md) | Registers named database and initialization options, Identity when selected, authentication, scanned features, and the base multi-provider DbContext. The provider callback must call an installed provider extension or context resolution will fail later. |

