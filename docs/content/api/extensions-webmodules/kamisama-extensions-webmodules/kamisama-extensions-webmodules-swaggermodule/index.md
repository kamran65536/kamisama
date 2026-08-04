# SwaggerModule

<a id="swaggermodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Extensions.WebModules/SwaggerModule.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/SwaggerModule.cs#L10)

Namespace: `KamiSama.Extensions.WebModules`

Kind: `Class`

## Description

Swagger Documentation and endpoint module. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class SwaggerModule(bool addEndPointInProduction, Action<SwaggerGenOptions>? genConfigure, Action<SwaggerUIOptions>? uiConfigure) : WebModule
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/SwaggerModule.cs#L10)

Swagger Documentation and endpoint module. Use it with the surrounding package APIs when composing application code.

```csharp
public class SwaggerModule(bool addEndPointInProduction, Action<SwaggerGenOptions>? genConfigure, Action<SwaggerUIOptions>? uiConfigure) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `addEndPointInProduction` | `bool` | `-` | The `addEndPointInProduction` value passed to this member. |
| `genConfigure` | `Action<SwaggerGenOptions>?` | `-` | The `genConfigure` value passed to this member. |
| `uiConfigure` | `Action<SwaggerUIOptions>?` | `-` | The `uiConfigure` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-18.md) | Runs the `ApplyConfigurationToAsync` operation on `SwaggerModule`. Use it when your code needs this specific behavior from the package. |
| [ConfigureServices](method-configureservices-13.md) | Runs the `ConfigureServices` operation on `SwaggerModule`. Use it when your code needs this specific behavior from the package. |
| [ConfigureSwaggerGen](method-configureswaggergen-31.md) | Configures swagger gen for inheritance. Use it with the surrounding package APIs when composing application code. |
| [ConfigureUiOptions](method-configureuioptions-38.md) | Configures swagger ui options for inheritance. Use it with the surrounding package APIs when composing application code. |

