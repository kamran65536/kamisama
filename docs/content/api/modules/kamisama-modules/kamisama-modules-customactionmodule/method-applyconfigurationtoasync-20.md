# ApplyConfigurationToAsync

[Back to CustomActionModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/CustomActionModule.cs:20](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/CustomActionModule.cs#L20)

Type: `KamiSama.Modules.CustomActionModule`

Kind: `Method`

## Description

Awaits the captured action when the captured condition is true; otherwise completes without invoking it. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public override async Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `app` | `WebApplication` | `-` | The built application passed to the action. |
| `cancellationToken` | `CancellationToken` | `-` | Ignored and not forwarded to the action. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task representing action execution. |

## Example

No concise standalone example is available yet.

