# SwaggerModule

<a id="swaggermodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules/SwaggerModule.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/SwaggerModule.cs#L13)

Namespace: `KamiSama.Modules`

Kind: `Class`

## Description

Registers Swagger generation and exposes Swagger document and UI middleware in Development or when production exposure is enabled. Generation and UI use separate callbacks.

## Declaration

```csharp
public class SwaggerModule(bool addEndPointInProduction, Action<SwaggerGenOptions>? genConfigure, Action<SwaggerUIOptions>? uiConfigure) : WebModule
```

## Example

```csharp
var builder = webBuilder.Extend()
    .AddModule(new SwaggerModule(addEndPointInProduction: false, genConfigure: null, uiConfigure: null));
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/SwaggerModule.cs#L13)

Registers Swagger generation and conditionally adds the Swagger document and UI middleware after build. Use it with the surrounding package APIs when composing application code.

```csharp
public class SwaggerModule(bool addEndPointInProduction, Action<SwaggerGenOptions>? genConfigure, Action<SwaggerUIOptions>? uiConfigure) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `addEndPointInProduction` | `bool` | `-` | Whether Swagger middleware should run outside the Development environment. |
| `genConfigure` | `Action<SwaggerGenOptions>?` | `-` | An optional callback for Swagger generation options. |
| `uiConfigure` | `Action<SwaggerUIOptions>?` | `-` | An optional callback for Swagger UI options. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-25.md) | Adds Swagger document and UI middleware in Development, or in every environment when the constructor flag is true. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-17.md) | Registers endpoint metadata exploration and Swagger generation, routing generation options through `ConfigureSwaggerGen`. Use it with the surrounding package APIs when composing application code. |
| [ConfigureSwaggerGen](method-configureswaggergen-39.md) | Invokes the constructor callback for Swagger generation options; derived modules can override this hook. Use it with the surrounding package APIs when composing application code. |
| [ConfigureUiOptions](method-configureuioptions-47.md) | Invokes the constructor callback for Swagger UI options; derived modules can override this hook. Use it with the surrounding package APIs when composing application code. |

