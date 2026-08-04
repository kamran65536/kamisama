# RazorComponentModule<TRootComponent>

<a id="razorcomponentmodule-trootcomponent"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Extensions.WebModules/RazorComponentModule.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/RazorComponentModule.cs#L7)

Namespace: `KamiSama.Extensions.WebModules`

Kind: `Class`

## Description

ASP.NET Core web-module implementation for `RazorComponentModule<TRootComponent>`. Add it through the extended web application builder to register services and apply the related middleware or endpoints.

## Declaration

```csharp
public class RazorComponentModule<TRootComponent>(Action<RazorComponentsEndpointConventionBuilder>? configure) : WebModule
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/RazorComponentModule.cs#L7)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public class RazorComponentModule<TRootComponent>(Action<RazorComponentsEndpointConventionBuilder>? configure) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `configure` | `Action<RazorComponentsEndpointConventionBuilder>?` | `-` | The `configure` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-15.md) | Runs the `ApplyConfigurationToAsync` operation on `RazorComponentModule<TRootComponent>`. Use it when your code needs this specific behavior from the package. |
| [ConfigureRazorComponents](method-configurerazorcomponents-26.md) | Configures the razor builder for inheritance. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-10.md) | Runs the `ConfigureServices` operation on `RazorComponentModule<TRootComponent>`. Use it when your code needs this specific behavior from the package. |

