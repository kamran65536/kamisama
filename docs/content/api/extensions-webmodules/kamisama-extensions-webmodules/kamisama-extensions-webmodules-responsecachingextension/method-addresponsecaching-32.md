# AddResponseCaching

[Back to ResponseCachingExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md)

Source: [src/KamiSama.Extensions.WebModules/ResponseCachingModule.cs:32](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/ResponseCachingModule.cs#L32)

Type: `KamiSama.Extensions.WebModules.ResponseCachingExtension`

Kind: `Method`

## Description

Adds response compression module to app. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddResponseCaching(this ExtendedWebApplicationBuilder builder, Action<ResponseCachingOptions>? configure);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The `builder` value passed to this member. |
| `configure` | `Action<ResponseCachingOptions>?` | `-` | The `configure` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | Returns a `ExtendedWebApplicationBuilder` value. |

## Example

No concise standalone example is available yet.

