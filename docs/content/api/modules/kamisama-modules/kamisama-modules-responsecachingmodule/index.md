# ResponseCachingModule

<a id="responsecachingmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules/ResponseCachingModule.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ResponseCachingModule.cs#L9)

Namespace: `KamiSama.Modules`

Kind: `Class`

## Description

Registers response-caching services but always throws `NotImplementedException` during post-build configuration. Adding it causes both extended build methods to fail.

## Declaration

```csharp
public class ResponseCachingModule(Action<ResponseCachingOptions>? configure) : WebModule
```

## Example

```csharp
var module = new ResponseCachingModule(options => options.MaximumBodySize = 1024);
// Do not add this module to a runnable builder: its application phase always throws.
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ResponseCachingModule.cs#L9)

Registers response-caching services but cannot complete the post-build phase because application configuration throws `NotImplementedException`. Use it with the surrounding package APIs when composing application code.

```csharp
public class ResponseCachingModule(Action<ResponseCachingOptions>? configure) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `configure` | `Action<ResponseCachingOptions>?` | `-` | An optional callback for response-caching options. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-28.md) | Always throws `NotImplementedException` and never adds response-caching middleware. Use it with the surrounding package APIs when composing application code. |
| [ConfigureResponseCachingOptions](method-configureresponsecachingoptions-21.md) | Invokes the constructor callback for response-caching options; derived modules can override this hook. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-13.md) | Registers response-caching services and invokes `ConfigureResponseCachingOptions` for options. Use it with the surrounding package APIs when composing application code. |

