# ApplyConfigurationToAsync

[Back to AntiForgeryModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/AntiForgeryModule.cs:19](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/AntiForgeryModule.cs#L19)

Type: `KamiSama.Modules.AntiForgeryModule`

Kind: `Method`

## Description

Adds ASP.NET Core antiforgery middleware by calling `AntiforgeryApplicationBuilderExtensions.UseAntiforgery`. Use it with the surrounding package APIs when composing application code.

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

