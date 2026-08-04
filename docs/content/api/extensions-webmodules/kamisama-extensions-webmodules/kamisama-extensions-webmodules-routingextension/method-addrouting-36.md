# AddRouting

[Back to RoutingExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md)

Source: [src/KamiSama.Extensions.WebModules/RoutingModule.cs:36](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/RoutingModule.cs#L36)

Type: `KamiSama.Extensions.WebModules.RoutingExtension`

Kind: `Method`

## Description

Runs the `AddRouting` operation on `RoutingExtension`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddRouting(this ExtendedWebApplicationBuilder builder, Action<RouteOptions>? configure);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The `builder` value passed to this member. |
| `configure` | `Action<RouteOptions>?` | `-` | The `configure` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | Returns a `ExtendedWebApplicationBuilder` value. |

## Example

No concise standalone example is available yet.

