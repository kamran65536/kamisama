# ResponseCompressionModule

<a id="responsecompressionmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules/ResponseCompressionModule.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ResponseCompressionModule.cs#L8)

Namespace: `KamiSama.Modules`

Kind: `Class`

## Description

Registers configured response-compression services and adds compression middleware after build. Middleware position follows module insertion order.

## Declaration

```csharp
public class ResponseCompressionModule(Action<ResponseCompressionOptions>? configure) : WebModule
```

## Example

```csharp
var builder = webBuilder.Extend()
    .AddModule(new ResponseCompressionModule(options => options.EnableForHttps = true));
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ResponseCompressionModule.cs#L8)

Registers response-compression services with optional configuration and adds compression middleware after build. Use it with the surrounding package APIs when composing application code.

```csharp
public class ResponseCompressionModule(Action<ResponseCompressionOptions>? configure) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `configure` | `Action<ResponseCompressionOptions>?` | `-` | An optional callback for response-compression options. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-28.md) | Adds response-compression middleware at this module&apos;s position in the ordered pipeline. Use it with the surrounding package APIs when composing application code. |
| [ConfigureCompressionOptions](method-configurecompressionoptions-20.md) | Invokes the constructor callback for response-compression options; derived modules can override this hook. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-12.md) | Registers response-compression services and invokes `ConfigureCompressionOptions` for options. Use it with the surrounding package APIs when composing application code. |

