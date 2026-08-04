# ResponseCachingModule

<a id="responsecachingmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Extensions.WebModules/ResponseCachingModule.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/ResponseCachingModule.cs#L8)

Namespace: `KamiSama.Extensions.WebModules`

Kind: `Class`

## Description

Adds response caching module to app. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class ResponseCachingModule(Action<ResponseCachingOptions>? configure) : WebModule
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/ResponseCachingModule.cs#L8)

Adds response caching module to app. Use it with the surrounding package APIs when composing application code.

```csharp
public class ResponseCachingModule(Action<ResponseCachingOptions>? configure) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `configure` | `Action<ResponseCachingOptions>?` | `-` | The `configure` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-21.md) | Runs the `ApplyConfigurationToAsync` operation on `ResponseCachingModule`. Use it when your code needs this specific behavior from the package. |
| [ConfigureResponseCachingOptions](method-configureresponsecachingoptions-18.md) | configures the response caching options, by default it calls configure parameter from the constructor. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-11.md) | Runs the `ConfigureServices` operation on `ResponseCachingModule`. Use it when your code needs this specific behavior from the package. |

