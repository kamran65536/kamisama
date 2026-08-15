# ApplyConfigurationToAsync

[Back to ResponseCachingModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/ResponseCachingModule.cs:28](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ResponseCachingModule.cs#L28)

Type: `KamiSama.Modules.ResponseCachingModule`

Kind: `Method`

## Description

Always throws `NotImplementedException` and never adds response-caching middleware. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `app` | `WebApplication` | `-` | The built application, which is not modified. |
| `cancellationToken` | `CancellationToken` | `-` | Ignored because the method throws immediately. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | This method does not return a task. |

## Example

No concise standalone example is available yet.

