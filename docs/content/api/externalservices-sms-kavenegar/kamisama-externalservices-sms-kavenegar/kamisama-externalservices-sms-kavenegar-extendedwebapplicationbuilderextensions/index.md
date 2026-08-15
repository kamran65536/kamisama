# ExtendedWebApplicationBuilderExtensions

<a id="extendedwebapplicationbuilderextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.Kavenegar](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.Kavenegar/KavenegarModule.cs:32](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Kavenegar/KavenegarModule.cs#L32)

Namespace: `KamiSama.ExternalServices.Sms.Kavenegar`

Kind: `Class`

## Description

Adds Kavenegar options binding and the scoped keyed `kavenegar` SMS provider. The current provider has an inverted validation defect and rejects a configured API key before sending.

## Declaration

```csharp
public static class ExtendedWebApplicationBuilderExtensions
```

## Example

```csharp
using KamiSama.ExternalServices.Sms;
using KamiSama.ExternalServices.Sms.Kavenegar;
using KamiSama.Modules;

var webBuilder = WebApplication.CreateBuilder(args);
var builder = webBuilder.Extend()
    .AddSmsCoreServicesModule(webBuilder.Configuration.GetSection("SmsDefaults"))
    .AddKavenegarSmsServiceModule(webBuilder.Configuration.GetSection("Sms:Kavenegar"));

var app = await builder.BuildAsync(CancellationToken.None);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddKavenegarSmsServiceModule](method-addkavenegarsmsservicemodule-40.md) | Adds the Kavenegar SMS module; its services are registered when `Build` or `BuildAsync` is called on the extended builder. Use it with the surrounding package APIs when composing application code. |

