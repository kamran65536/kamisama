# AddKamiSamaIdentityModule

[Back to ExtendedWebApplicationBuilderExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/KamiSamaIdentityWebModule.cs:135](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/KamiSamaIdentityWebModule.cs#L135)

Type: `KamiSama.Modules.Identity.ExtendedWebApplicationBuilderExtensions`

Kind: `Method`

## Description

Adds Identity registration and startup initialization to an extended application builder. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddKamiSamaIdentityModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection moduleSection, IConfigurationSection databaseSection, bool registerIdentity = true, bool useJwtAuth = true, Action<IMultiProviderDbContextBuilder<KamiSamaIdentityDbContext>>? configureDbContext = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The extended application builder. |
| `moduleSection` | `IConfigurationSection` | `-` | The Identity options, JWT, and initialization section. |
| `databaseSection` | `IConfigurationSection` | `-` | The database provider and connection-string section. |
| `registerIdentity` | `bool` | `true` | Whether Core should register ASP.NET Core Identity services. |
| `useJwtAuth` | `bool` | `true` | Whether Core should configure JWT bearer rather than Identity application-scheme defaults. |
| `configureDbContext` | `Action<IMultiProviderDbContextBuilder<KamiSamaIdentityDbContext>>?` | `null` | The required-in-practice callback that adds exactly one installed Identity database provider. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | The same builder for fluent module composition. |

## Example

```csharp
ExtendedWebApplicationBuilder builder = webBuilder.Extend().AddKamiSamaIdentityModule(
    identitySection, databaseSection, registerIdentity: true, useJwtAuth: true,
    configureDbContext: database => database.AddPostgresqlIdentityDbContext());
```

