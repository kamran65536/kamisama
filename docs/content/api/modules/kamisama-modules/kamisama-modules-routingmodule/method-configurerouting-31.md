# ConfigureRouting

[Back to RoutingModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/RoutingModule.cs:31](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/RoutingModule.cs#L31)

Type: `KamiSama.Modules.RoutingModule`

Kind: `Method`

## Description

Invokes the constructor callback for route options; derived modules can override this hook. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected virtual void ConfigureRouting(RouteOptions routeOptions);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `routeOptions` | `RouteOptions` | `-` | The route options configured before build. |

## Example

No concise standalone example is available yet.

