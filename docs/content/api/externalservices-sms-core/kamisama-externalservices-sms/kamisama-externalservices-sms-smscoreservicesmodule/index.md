# SmsCoreServicesModule

<a id="smscoreservicesmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.Core/SmsCoreServicesModule.cs:14](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Core/SmsCoreServicesModule.cs#L14)

Namespace: `KamiSama.ExternalServices.Sms`

Kind: `Class`

## Description

Registers the scoped unkeyed SMS dispatcher, scoped keyed `mock` provider, and default-provider options. Its registrations run when the containing `ExtendedWebApplicationBuilder` is built.

## Declaration

```csharp
public class SmsCoreServicesModule(IConfigurationSection defaultsSection) : WebModule
```

## Example

```csharp
using KamiSama.ExternalServices.Sms;
using KamiSama.Modules;

var webBuilder = WebApplication.CreateBuilder(args);
var builder = webBuilder.Extend();
builder.AddModule(new SmsCoreServicesModule(
    webBuilder.Configuration.GetSection("SmsDefaults")));

var app = await builder.BuildAsync(CancellationToken.None);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Core/SmsCoreServicesModule.cs#L14)

Registers the scoped, unkeyed SMS dispatcher, the scoped keyed `mock` provider, and default-provider options. Add this module when application code should resolve `ISendSms` without a key and dispatch through the configured provider key.

```csharp
public class SmsCoreServicesModule(IConfigurationSection defaultsSection) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `defaultsSection` | `IConfigurationSection` | `-` | The configuration section containing the `sms` provider key. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-32.md) | Completes the module lifecycle without applying middleware or endpoints. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-20.md) | Binds `SmsDefaultsOptions` and scans this package for its scoped keyed and unkeyed SMS registrations. Use it with the surrounding package APIs when composing application code. |

