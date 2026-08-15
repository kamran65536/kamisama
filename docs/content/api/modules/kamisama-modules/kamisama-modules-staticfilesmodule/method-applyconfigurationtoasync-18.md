# ApplyConfigurationToAsync

[Back to StaticFilesModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/StaticFilesModule.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/StaticFilesModule.cs#L18)

Type: `KamiSama.Modules.StaticFilesModule`

Kind: `Method`

## Description

Maps static assets by calling `MapStaticAssets` at this module&apos;s position in post-build order. Use it with the surrounding package APIs when composing application code.

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

