# ForwardedHeadersModule

<a id="forwardedheadersmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules/ForwardedHeadersModule.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ForwardedHeadersModule.cs#L8)

Namespace: `KamiSama.Modules`

Kind: `Class`

## Description

Constructs forwarded-header options after build and adds the middleware. It does not register services during the first module phase.

## Declaration

```csharp
public class ForwardedHeadersModule(Action<ForwardedHeadersOptions>? configure) : WebModule
```

## Example

```csharp
using Microsoft.AspNetCore.HttpOverrides;

var builder = webBuilder.Extend()
    .AddModule(new ForwardedHeadersModule(options =>
        options.ForwardedHeaders = ForwardedHeaders.XForwardedFor));
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ForwardedHeadersModule.cs#L8)

Creates forwarded-header options after build and adds forwarded-header middleware with caller or derived-type customization. Use it with the surrounding package APIs when composing application code.

```csharp
public class ForwardedHeadersModule(Action<ForwardedHeadersOptions>? configure) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `configure` | `Action<ForwardedHeadersOptions>?` | `-` | An optional callback that configures the newly created middleware options. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-19.md) | Creates options, invokes `ConfigureForwaredHeadersOptions`, and adds forwarded-header middleware at this module&apos;s ordered position. Use it with the surrounding package APIs when composing application code. |
| [ConfigureForwaredHeadersOptions](method-configureforwaredheadersoptions-33.md) | Invokes the constructor callback for forwarded-header options; derived modules can override this hook. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-12.md) | Performs no service registration because the middleware options are constructed during the post-build phase. Use it with the surrounding package APIs when composing application code. |

