# ExtendedWebApplicationBuilderExtensions

<a id="extendedwebapplicationbuilderextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.Core/SmsCoreServicesModule.cs:41](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Core/SmsCoreServicesModule.cs#L41)

Namespace: `KamiSama.ExternalServices.Sms`

Kind: `Class`

## Description

Adds core SMS provider selection, the unkeyed dispatcher, and the keyed `mock` registration to an `ExtendedWebApplicationBuilder`. Call `Build` or `BuildAsync` to apply the module registrations.

## Declaration

```csharp
public static class ExtendedWebApplicationBuilderExtensions
```

## Example

```csharp
using KamiSama.ExternalServices.Sms;
using KamiSama.Modules;

var webBuilder = WebApplication.CreateBuilder(args);
var builder = webBuilder.Extend()
    .AddSmsCoreServicesModule(webBuilder.Configuration.GetSection("SmsDefaults"));

var app = await builder.BuildAsync(CancellationToken.None);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddSmsCoreServicesModule](method-addsmscoreservicesmodule-49.md) | Adds the core SMS module; its services are registered when `Build` or `BuildAsync` is called on the extended builder. Use it with the surrounding package APIs when composing application code. |

