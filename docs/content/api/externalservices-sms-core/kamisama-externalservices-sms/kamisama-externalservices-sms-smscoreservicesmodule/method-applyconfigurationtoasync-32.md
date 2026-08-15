# ApplyConfigurationToAsync

[Back to SmsCoreServicesModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.Core](../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.Core/SmsCoreServicesModule.cs:32](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Core/SmsCoreServicesModule.cs#L32)

Type: `KamiSama.ExternalServices.Sms.SmsCoreServicesModule`

Kind: `Method`

## Description

Completes the module lifecycle without applying middleware or endpoints. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `app` | `WebApplication` | `-` | The built web application. |
| `cancellationToken` | `CancellationToken` | `-` | The token used to cancel post-build configuration. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A completed task because this module has no post-build work. |

## Example

No concise standalone example is available yet.

