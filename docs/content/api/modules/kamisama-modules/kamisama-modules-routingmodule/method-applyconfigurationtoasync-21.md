# ApplyConfigurationToAsync

[Back to RoutingModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/RoutingModule.cs:21](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/RoutingModule.cs#L21)

Type: `KamiSama.Modules.RoutingModule`

Kind: `Method`

## Description

Adds routing middleware at this module&apos;s position in the ordered pipeline. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `app` | `WebApplication` | `-` | The built application. |
| `cancellationToken` | `CancellationToken` | `-` | Ignored by this implementation. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | An already completed task. |

## Example

No concise standalone example is available yet.

