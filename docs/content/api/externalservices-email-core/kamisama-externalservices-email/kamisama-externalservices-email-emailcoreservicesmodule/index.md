# EmailCoreServicesModule

<a id="emailcoreservicesmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Email.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Email.Core/EmailCoreServicesModule.cs:14](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Core/EmailCoreServicesModule.cs#L14)

Namespace: `KamiSama.ExternalServices.Email`

Kind: `Class`

## Description

Registers the default-provider options and scans the core email package for service implementations. Add it when `ISendEmail` should dispatch to the keyed provider selected by configuration.

## Declaration

```csharp
public class EmailCoreServicesModule(IConfigurationSection defaultsSection) : WebModule
```

## Example

```csharp
using KamiSama.ExternalServices.Email;
using KamiSama.Modules;

var webBuilder = WebApplication.CreateBuilder(args);
var builder = webBuilder.Extend();
builder.AddModule(new EmailCoreServicesModule(
    webBuilder.Configuration.GetSection("EmailDefaults")));
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Core/EmailCoreServicesModule.cs#L14)

Registers provider-selecting email services and binds the default provider configuration. Add this module when the application should resolve `ISendEmail` through a configured keyed provider.

```csharp
public class EmailCoreServicesModule(IConfigurationSection defaultsSection) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `defaultsSection` | `IConfigurationSection` | `-` | The configuration section containing the `email` provider key. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-32.md) | Completes the module lifecycle without applying middleware or endpoints. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-20.md) | Binds `EmailDefaultsOptions` and scans this package for its email service registrations. Use it with the surrounding package APIs when composing application code. |

