# ApplyConfigurationToAsync

[Back to WebModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md)

Source: [src/KamiSama.Extensions.WebModules/WebModule.cs:21](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/WebModule.cs#L21)

Type: `KamiSama.Extensions.WebModules.WebModule`

Kind: `Method`

## Description

Applies middleware, endpoint mapping, or post-build application configuration after the app is built.

## Declaration

```csharp
public abstract Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `app` | `WebApplication` | `-` | The `app` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

