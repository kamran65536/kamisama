# ApplyConfigurationToAsync

[Back to ControllersModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/ControllersModule.cs:22](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ControllersModule.cs#L22)

Type: `KamiSama.Modules.ControllersModule`

Kind: `Method`

## Description

Maps attribute-routed controller endpoints at this module&apos;s position in post-build order. Use it with the surrounding package APIs when composing application code.

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

