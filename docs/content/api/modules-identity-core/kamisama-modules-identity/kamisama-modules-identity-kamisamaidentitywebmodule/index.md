# KamiSamaIdentityWebModule

<a id="kamisamaidentitywebmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/KamiSamaIdentityWebModule.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/KamiSamaIdentityWebModule.cs#L17)

Namespace: `KamiSama.Modules.Identity`

Kind: `Class`

## Description

ASP.NET Core web-module implementation for `KamiSamaIdentityWebModule`. Add it through the extended web application builder to register services and apply the related middleware or endpoints.

## Declaration

```csharp
public class KamiSamaIdentityWebModule(
	IConfigurationSection moduleSection,
	IConfigurationSection databaseSection,
	bool registerIdentity,
	bool useJwtAuth,
	Action<IMultiProviderDbContextBuilder<KamiSamaIdentityDbContext>>? configureDbContext = null) : WebModule
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/KamiSamaIdentityWebModule.cs#L17)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

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
| `moduleSection` | `IConfigurationSection` | `-` | The `moduleSection` value passed to this member. |
| `databaseSection` | `IConfigurationSection` | `-` | The `databaseSection` value passed to this member. |
| `registerIdentity` | `bool` | `-` | The `registerIdentity` value passed to this member. |
| `useJwtAuth` | `bool` | `-` | The `useJwtAuth` value passed to this member. |
| `configureDbContext` | `Action<IMultiProviderDbContextBuilder<KamiSamaIdentityDbContext>>?` | `null` | The `configureDbContext` value passed to this member. |

## Members

### Fields

| Member | Description |
| --- | --- |
| [ModuleName](field-modulename-24.md) | Stores the `ModuleName` value for `KamiSamaIdentityWebModule`. Use it where the package exposes this field as part of its API. |

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-92.md) | Runs the `ApplyConfigurationToAsync` operation on `KamiSamaIdentityWebModule`. Use it when your code needs this specific behavior from the package. |
| [ConfigureServices](method-configureservices-26.md) | Runs the `ConfigureServices` operation on `KamiSamaIdentityWebModule`. Use it when your code needs this specific behavior from the package. |

