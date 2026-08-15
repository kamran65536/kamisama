# AddForwardedHeaders

[Back to ForwardedHeadersExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/ForwardedHeadersModule.cs:47](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ForwardedHeadersModule.cs#L47)

Type: `KamiSama.Modules.ForwardedHeadersExtension`

Kind: `Method`

## Description

Queues forwarded-header middleware with optional options customization. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddForwardedHeaders(this ExtendedWebApplicationBuilder builder, Action<ForwardedHeadersOptions>? configure = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The builder that receives the module. |
| `configure` | `Action<ForwardedHeadersOptions>?` | `null` | An optional forwarded-header options callback. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | The same builder for fluent composition. |

## Example

```csharp
using Microsoft.AspNetCore.HttpOverrides;

ExtendedWebApplicationBuilder builder = webBuilder.Extend()
    .AddForwardedHeaders(options => options.ForwardedHeaders = ForwardedHeaders.XForwardedFor);
```

