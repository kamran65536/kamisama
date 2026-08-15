# ApplyConfigurationToAsync

[Back to LocalizationModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Core](../../index.md)

Source: [src/KamiSama.Modules.Localization.Core/LocalizationModule.cs:43](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/LocalizationModule.cs#L43)

Type: `KamiSama.Modules.Localization.LocalizationModule`

Kind: `Method`

## Description

Performs no post-build work because the preceding request-localization module applies the middleware. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `app` | `WebApplication` | `-` | The built application; this implementation does not modify it. |
| `cancellationToken` | `CancellationToken` | `-` | The token supplied by the builder; this implementation ignores it. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | An already completed task. |

## Example

No concise standalone example is available yet.

