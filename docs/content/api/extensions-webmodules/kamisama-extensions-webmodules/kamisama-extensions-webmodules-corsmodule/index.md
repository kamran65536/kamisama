# CorsModule

<a id="corsmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Extensions.WebModules/CorsModule.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/CorsModule.cs#L8)

Namespace: `KamiSama.Extensions.WebModules`

Kind: `Class`

## Description

ASP.NET Core web-module implementation for `CorsModule`. Add it through the extended web application builder to register services and apply the related middleware or endpoints.

## Declaration

```csharp
public class CorsModule(Action<CorsOptions>? configOptions, Action<CorsPolicyBuilder>? configurePolicy) : WebModule
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/CorsModule.cs#L8)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public class CorsModule(Action<CorsOptions>? configOptions, Action<CorsPolicyBuilder>? configurePolicy) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `configOptions` | `Action<CorsOptions>?` | `-` | The `configOptions` value passed to this member. |
| `configurePolicy` | `Action<CorsPolicyBuilder>?` | `-` | The `configurePolicy` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-16.md) | Runs the `ApplyConfigurationToAsync` operation on `CorsModule`. Use it when your code needs this specific behavior from the package. |
| [ConfigureCorsOptions](method-configurecorsoptions-26.md) | Configures the cors options for inheritance. Use it with the surrounding package APIs when composing application code. |
| [ConfigureCorsPolicy](method-configurecorspolicy-34.md) | Configures the cors builder for inheritance. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-11.md) | Runs the `ConfigureServices` operation on `CorsModule`. Use it when your code needs this specific behavior from the package. |

