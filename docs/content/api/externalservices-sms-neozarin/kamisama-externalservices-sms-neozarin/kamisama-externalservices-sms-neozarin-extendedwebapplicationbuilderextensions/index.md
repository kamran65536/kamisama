# ExtendedWebApplicationBuilderExtensions

<a id="extendedwebapplicationbuilderextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.NeoZarin](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.NeoZarin/NeoZarinSmsModule.cs:33](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.NeoZarin/NeoZarinSmsModule.cs#L33)

Namespace: `KamiSama.ExternalServices.Sms.NeoZarin`

Kind: `Class`

## Description

Adds NeoZarin options binding and the scoped keyed `neo-zarin` SMS provider. Register `HttpClient` and KamiSama RestSharp first; the current provider also has an inverted validation defect.

## Declaration

```csharp
public static class ExtendedWebApplicationBuilderExtensions
```

## Example

```csharp
using KamiSama.Extensions.RestSharp;
using KamiSama.ExternalServices.Sms;
using KamiSama.ExternalServices.Sms.NeoZarin;
using KamiSama.Modules;

var webBuilder = WebApplication.CreateBuilder(args);
webBuilder.Services.AddHttpClient();
webBuilder.Services.AddKamiSamaRestSharp();

var builder = webBuilder.Extend()
    .AddSmsCoreServicesModule(webBuilder.Configuration.GetSection("SmsDefaults"))
    .AddNeoZarinSmsModule(webBuilder.Configuration.GetSection("Sms:NeoZarin"));

var app = await builder.BuildAsync(CancellationToken.None);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddNeoZarinSmsModule](method-addneozarinsmsmodule-41.md) | Adds the NeoZarin SMS module; register `HttpClient` and KamiSama RestSharp first, then call `Build` or `BuildAsync` so this module registers its services. Use it with the surrounding package APIs when composing application code. |

