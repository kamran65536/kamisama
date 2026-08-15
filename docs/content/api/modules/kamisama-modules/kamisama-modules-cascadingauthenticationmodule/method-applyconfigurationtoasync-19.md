# ApplyConfigurationToAsync

[Back to CascadingAuthenticationModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/CascadingAuthenticationModule.cs:19](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/CascadingAuthenticationModule.cs#L19)

Type: `KamiSama.Modules.CascadingAuthenticationModule`

Kind: `Method`

## Description

Performs no post-build work. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `app` | `WebApplication` | `-` | The built application, which this implementation leaves unchanged. |
| `cancellationToken` | `CancellationToken` | `-` | Ignored by this implementation. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | An already completed task. |

## Example

No concise standalone example is available yet.

