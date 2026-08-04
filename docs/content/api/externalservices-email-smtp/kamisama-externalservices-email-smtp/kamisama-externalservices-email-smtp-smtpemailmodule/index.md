# SmtpEmailModule

<a id="smtpemailmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Email.Smtp](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Email.Smtp/SmtpEmailModule.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Smtp/SmtpEmailModule.cs#L8)

Namespace: `KamiSama.ExternalServices.Email.Smtp`

Kind: `Class`

## Description

ASP.NET Core web-module implementation for `SmtpEmailModule`. Add it through the extended web application builder to register services and apply the related middleware or endpoints.

## Declaration

```csharp
internal class SmtpEmailModule(IConfigurationSection smtpServiceSection) : WebModule
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Smtp/SmtpEmailModule.cs#L8)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class SmtpEmailModule(IConfigurationSection smtpServiceSection) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `smtpServiceSection` | `IConfigurationSection` | `-` | The `smtpServiceSection` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-17.md) | Runs the `ApplyConfigurationToAsync` operation on `SmtpEmailModule`. Use it when your code needs this specific behavior from the package. |
| [ConfigureServices](method-configureservices-10.md) | Runs the `ConfigureServices` operation on `SmtpEmailModule`. Use it when your code needs this specific behavior from the package. |

