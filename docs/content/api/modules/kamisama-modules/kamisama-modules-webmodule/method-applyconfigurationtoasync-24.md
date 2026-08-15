# ApplyConfigurationToAsync

[Back to WebModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/WebModule.cs:24](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/WebModule.cs#L24)

Type: `KamiSama.Modules.WebModule`

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
| `app` | `WebApplication` | `-` | The built application to configure. |
| `cancellationToken` | `CancellationToken` | `-` | The token supplied to `ExtendedWebApplicationBuilder.BuildAsync`. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that completes when this module&apos;s post-build configuration is finished. |

## Example

No concise standalone example is available yet.

