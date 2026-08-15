# AddCors

[Back to CorsExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/CorsModule.cs:55](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/CorsModule.cs#L55)

Type: `KamiSama.Modules.CorsExtension`

Kind: `Method`

## Description

Queues CORS services and inline policy middleware. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddCors(this ExtendedWebApplicationBuilder builder, Action<CorsOptions>? configOptions = null, Action<CorsPolicyBuilder>? configurePolicy = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The builder that receives the module. |
| `configOptions` | `Action<CorsOptions>?` | `null` | An optional service-level CORS options callback. |
| `configurePolicy` | `Action<CorsPolicyBuilder>?` | `null` | An optional inline middleware policy callback. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | The same builder for fluent composition. |

## Example

```csharp
ExtendedWebApplicationBuilder builder = webBuilder.Extend()
    .AddCors(configurePolicy: policy => policy.AllowAnyOrigin());
```

