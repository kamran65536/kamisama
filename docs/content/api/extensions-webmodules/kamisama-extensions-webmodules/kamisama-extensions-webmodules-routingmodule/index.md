# RoutingModule

<a id="routingmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Extensions.WebModules/RoutingModule.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/RoutingModule.cs#L8)

Namespace: `KamiSama.Extensions.WebModules`

Kind: `Class`

## Description

ASP.NET Core web-module implementation for `RoutingModule`. Add it through the extended web application builder to register services and apply the related middleware or endpoints.

## Declaration

```csharp
public class RoutingModule(Action<RouteOptions>? configure) : WebModule
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/RoutingModule.cs#L8)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public class RoutingModule(Action<RouteOptions>? configure) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `configure` | `Action<RouteOptions>?` | `-` | The `configure` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-16.md) | Runs the `ApplyConfigurationToAsync` operation on `RoutingModule`. Use it when your code needs this specific behavior from the package. |
| [ConfigureRouting](method-configurerouting-25.md) | Configures route options for inheritance. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-11.md) | Runs the `ConfigureServices` operation on `RoutingModule`. Use it when your code needs this specific behavior from the package. |

