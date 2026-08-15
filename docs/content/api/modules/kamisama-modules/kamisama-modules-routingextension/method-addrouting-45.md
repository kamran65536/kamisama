# AddRouting

[Back to RoutingExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/RoutingModule.cs:45](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/RoutingModule.cs#L45)

Type: `KamiSama.Modules.RoutingExtension`

Kind: `Method`

## Description

Queues route-options registration and routing middleware. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddRouting(this ExtendedWebApplicationBuilder builder, Action<RouteOptions>? configure);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The builder that receives the module. |
| `configure` | `Action<RouteOptions>?` | `-` | An optional route-options callback. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | The same builder for fluent composition. |

## Example

```csharp
ExtendedWebApplicationBuilder builder = webBuilder.Extend()
    .AddRouting(options => options.LowercaseUrls = true);
```

