# AddSwagger

[Back to SwaggerModuleExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/SwaggerModule.cs:63](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/SwaggerModule.cs#L63)

Type: `KamiSama.Modules.SwaggerModuleExtension`

Kind: `Method`

## Description

Queues Swagger generation services and environment-sensitive document and UI middleware. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddSwagger(this ExtendedWebApplicationBuilder builder, bool addEndPointInProduction = false, Action<SwaggerGenOptions>? genConfigure = null, Action<SwaggerUIOptions>? uiConfigure = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The builder that receives the module. |
| `addEndPointInProduction` | `bool` | `false` | Whether to expose Swagger outside Development. |
| `genConfigure` | `Action<SwaggerGenOptions>?` | `null` | An optional generation-options callback. |
| `uiConfigure` | `Action<SwaggerUIOptions>?` | `null` | An optional UI-options callback. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | The same builder for fluent composition. |

## Example

```csharp
using KamiSama.Modules;

var builder = WebApplication.CreateBuilder(args).Extend().AddSwagger();
```

