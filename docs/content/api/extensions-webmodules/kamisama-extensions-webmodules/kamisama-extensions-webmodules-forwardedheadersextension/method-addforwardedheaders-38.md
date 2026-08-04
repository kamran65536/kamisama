# AddForwardedHeaders

[Back to ForwardedHeadersExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md)

Source: [src/KamiSama.Extensions.WebModules/ForwardedHeadersModule.cs:38](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/ForwardedHeadersModule.cs#L38)

Type: `KamiSama.Extensions.WebModules.ForwardedHeadersExtension`

Kind: `Method`

## Description

Runs the `AddForwardedHeaders` operation on `ForwardedHeadersExtension`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddForwardedHeaders(this ExtendedWebApplicationBuilder builder, Action<ForwardedHeadersOptions>? configure = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The `builder` value passed to this member. |
| `configure` | `Action<ForwardedHeadersOptions>?` | `null` | The `configure` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | Returns a `ExtendedWebApplicationBuilder` value. |

## Example

No concise standalone example is available yet.

