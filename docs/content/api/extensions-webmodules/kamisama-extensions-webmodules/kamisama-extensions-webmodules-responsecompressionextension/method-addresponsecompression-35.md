# AddResponseCompression

[Back to ResponseCompressionExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md)

Source: [src/KamiSama.Extensions.WebModules/ResponseCompressionModule.cs:35](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/ResponseCompressionModule.cs#L35)

Type: `KamiSama.Extensions.WebModules.ResponseCompressionExtension`

Kind: `Method`

## Description

Adds response compression module to app. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddResponseCompression(this ExtendedWebApplicationBuilder builder, Action<ResponseCompressionOptions>? configure);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The `builder` value passed to this member. |
| `configure` | `Action<ResponseCompressionOptions>?` | `-` | The `configure` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | Returns a `ExtendedWebApplicationBuilder` value. |

## Example

No concise standalone example is available yet.

