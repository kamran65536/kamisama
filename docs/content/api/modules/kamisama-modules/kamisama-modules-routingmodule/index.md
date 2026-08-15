# RoutingModule

<a id="routingmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules/RoutingModule.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/RoutingModule.cs#L9)

Namespace: `KamiSama.Modules`

Kind: `Class`

## Description

Registers route options and explicitly adds routing middleware after build. Add endpoint-producing modules in an order consistent with the intended pipeline.

## Declaration

```csharp
public class RoutingModule(Action<RouteOptions>? configure) : WebModule
```

## Example

```csharp
var builder = webBuilder.Extend()
    .AddModule(new RoutingModule(options => options.LowercaseUrls = true));
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/RoutingModule.cs#L9)

Registers route options before build and explicitly adds routing middleware afterward. Use it with the surrounding package APIs when composing application code.

```csharp
public class RoutingModule(Action<RouteOptions>? configure) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `configure` | `Action<RouteOptions>?` | `-` | An optional callback for route options. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-21.md) | Adds routing middleware at this module&apos;s position in the ordered pipeline. Use it with the surrounding package APIs when composing application code. |
| [ConfigureRouting](method-configurerouting-31.md) | Invokes the constructor callback for route options; derived modules can override this hook. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-13.md) | Registers route-options configuration through `ConfigureRouting`. Use it with the surrounding package APIs when composing application code. |

