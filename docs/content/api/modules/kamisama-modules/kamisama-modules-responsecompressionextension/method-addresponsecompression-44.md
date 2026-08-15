# AddResponseCompression

[Back to ResponseCompressionExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/ResponseCompressionModule.cs:44](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ResponseCompressionModule.cs#L44)

Type: `KamiSama.Modules.ResponseCompressionExtension`

Kind: `Method`

## Description

Queues response-compression services and middleware. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddResponseCompression(this ExtendedWebApplicationBuilder builder, Action<ResponseCompressionOptions>? configure);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The builder that receives the module. |
| `configure` | `Action<ResponseCompressionOptions>?` | `-` | An optional response-compression options callback. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | The same builder for fluent composition. |

## Example

```csharp
ExtendedWebApplicationBuilder builder = webBuilder.Extend()
    .AddResponseCompression(options => options.EnableForHttps = true);
```

