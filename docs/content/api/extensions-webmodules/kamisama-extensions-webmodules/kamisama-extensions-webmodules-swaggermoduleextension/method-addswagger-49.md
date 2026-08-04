# AddSwagger

[Back to SwaggerModuleExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md)

Source: [src/KamiSama.Extensions.WebModules/SwaggerModule.cs:49](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/SwaggerModule.cs#L49)

Type: `KamiSama.Extensions.WebModules.SwaggerModuleExtension`

Kind: `Method`

## Description

Adds Swagger cofniguration to app. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddSwagger(this ExtendedWebApplicationBuilder builder, bool addEndPointInProduction = false, Action<SwaggerGenOptions>? genConfigure = null, Action<SwaggerUIOptions>? uiConfigure = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The `builder` value passed to this member. |
| `addEndPointInProduction` | `bool` | `false` | The `addEndPointInProduction` value passed to this member. |
| `genConfigure` | `Action<SwaggerGenOptions>?` | `null` | The `genConfigure` value passed to this member. |
| `uiConfigure` | `Action<SwaggerUIOptions>?` | `null` | The `uiConfigure` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | Returns a `ExtendedWebApplicationBuilder` value. |

## Example

```csharp
using KamiSama.Extensions.WebModules;

var builder = WebApplication.CreateBuilder(args).Extend().AddSwagger();
```

