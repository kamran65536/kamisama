# AddRequestLocalization

[Back to RequestLocalizationExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md)

Source: [src/KamiSama.Extensions.WebModules/RequestLocalizationModule.cs:37](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/RequestLocalizationModule.cs#L37)

Type: `KamiSama.Extensions.WebModules.RequestLocalizationExtension`

Kind: `Method`

## Description

Adds Localization to the module. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddRequestLocalization(this ExtendedWebApplicationBuilder builder, Action<RequestLocalizationOptions> configure);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The `builder` value passed to this member. |
| `configure` | `Action<RequestLocalizationOptions>` | `-` | The `configure` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | Returns a `ExtendedWebApplicationBuilder` value. |

## Example

No concise standalone example is available yet.

