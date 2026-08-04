# AddKamiSamaIdentityModule

[Back to ExtendedWebApplicationBuilderExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/KamiSamaIdentityWebModule.cs:107](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/KamiSamaIdentityWebModule.cs#L107)

Type: `KamiSama.Modules.Identity.ExtendedWebApplicationBuilderExtensions`

Kind: `Method`

## Description

Runs the `AddKamiSamaIdentityModule` operation on `ExtendedWebApplicationBuilderExtensions`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddKamiSamaIdentityModule(this ExtendedWebApplicationBuilder builder, IConfigurationSection moduleSection, IConfigurationSection databaseSection, bool registerIdentity = true, bool useJwtAuth = true, Action<IMultiProviderDbContextBuilder<KamiSamaIdentityDbContext>>? configureDbContext = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The `builder` value passed to this member. |
| `moduleSection` | `IConfigurationSection` | `-` | The `moduleSection` value passed to this member. |
| `databaseSection` | `IConfigurationSection` | `-` | The `databaseSection` value passed to this member. |
| `registerIdentity` | `bool` | `true` | The `registerIdentity` value passed to this member. |
| `useJwtAuth` | `bool` | `true` | The `useJwtAuth` value passed to this member. |
| `configureDbContext` | `Action<IMultiProviderDbContextBuilder<KamiSamaIdentityDbContext>>?` | `null` | The `configureDbContext` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | Returns a `ExtendedWebApplicationBuilder` value. |

## Example

No concise standalone example is available yet.

