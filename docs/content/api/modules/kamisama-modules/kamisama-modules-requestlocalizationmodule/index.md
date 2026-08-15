# RequestLocalizationModule

<a id="requestlocalizationmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules/RequestLocalizationModule.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/RequestLocalizationModule.cs#L9)

Namespace: `KamiSama.Modules`

Kind: `Class`

## Description

Registers localization and request-localization options before build, then adds request-localization middleware. The required callback defines provider and supported-culture behavior.

## Declaration

```csharp
public class RequestLocalizationModule(Action<RequestLocalizationOptions> configure) : WebModule
```

## Example

```csharp
using System.Globalization;
using Microsoft.AspNetCore.Localization;

var builder = webBuilder.Extend().AddModule(new RequestLocalizationModule(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = [new CultureInfo("en-US")];
    options.SupportedUICultures = options.SupportedCultures;
}));
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/RequestLocalizationModule.cs#L9)

Registers localization and configured request-localization options before build, then adds request-localization middleware afterward. Use it with the surrounding package APIs when composing application code.

```csharp
public class RequestLocalizationModule(Action<RequestLocalizationOptions> configure) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `configure` | `Action<RequestLocalizationOptions>` | `-` | The required callback used to configure request localization. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-22.md) | Adds request-localization middleware using the options registered during the service phase. Use it with the surrounding package APIs when composing application code. |
| [ConfigureRequestLocalization](method-configurerequestlocalization-32.md) | Invokes the required constructor callback for request-localization options; derived modules can override this hook. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-13.md) | Registers request-localization options through `ConfigureRequestLocalization` and adds localization services. Use it with the surrounding package APIs when composing application code. |

