# CorsModule

<a id="corsmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules/CorsModule.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/CorsModule.cs#L10)

Namespace: `KamiSama.Modules`

Kind: `Class`

## Description

Registers CORS options and adds inline-policy CORS middleware. Service options and middleware policy use separate callbacks.

## Declaration

```csharp
public class CorsModule(Action<CorsOptions>? configOptions, Action<CorsPolicyBuilder>? configurePolicy) : WebModule
```

## Example

```csharp
var builder = webBuilder.Extend()
    .AddModule(new CorsModule(null, policy => policy.AllowAnyOrigin()));
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/CorsModule.cs#L10)

Registers CORS options before build and adds policy middleware configured by a callback afterward. Use it with the surrounding package APIs when composing application code.

```csharp
public class CorsModule(Action<CorsOptions>? configOptions, Action<CorsPolicyBuilder>? configurePolicy) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `configOptions` | `Action<CorsOptions>?` | `-` | An optional callback used while CORS services configure named policies and options. |
| `configurePolicy` | `Action<CorsPolicyBuilder>?` | `-` | An optional callback used to build the inline middleware policy. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-22.md) | Adds CORS middleware with the inline policy produced by `ConfigureCorsPolicy`. Use it with the surrounding package APIs when composing application code. |
| [ConfigureCorsOptions](method-configurecorsoptions-32.md) | Invokes the constructor callback for service-level CORS options; derived modules can override the hook. Use it with the surrounding package APIs when composing application code. |
| [ConfigureCorsPolicy](method-configurecorspolicy-40.md) | Invokes the constructor callback for the inline CORS policy; derived modules can override the hook. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-14.md) | Registers CORS services and routes options configuration through `ConfigureCorsOptions`. Use it with the surrounding package APIs when composing application code. |

