# NeoZarinSmsModule

<a id="neozarinsmsmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.NeoZarin](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.NeoZarin/NeoZarinSmsModule.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.NeoZarin/NeoZarinSmsModule.cs#L9)

Namespace: `KamiSama.ExternalServices.Sms.NeoZarin`

Kind: `Class`

## Description

ASP.NET Core web-module implementation for `NeoZarinSmsModule`. Add it through the extended web application builder to register services and apply the related middleware or endpoints.

## Declaration

```csharp
internal class NeoZarinSmsModule(IConfigurationSection neoZarinSection) : WebModule
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.NeoZarin/NeoZarinSmsModule.cs#L9)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class NeoZarinSmsModule(IConfigurationSection neoZarinSection) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `neoZarinSection` | `IConfigurationSection` | `-` | The `neoZarinSection` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-18.md) | Runs the `ApplyConfigurationToAsync` operation on `NeoZarinSmsModule`. Use it when your code needs this specific behavior from the package. |
| [ConfigureServices](method-configureservices-11.md) | Runs the `ConfigureServices` operation on `NeoZarinSmsModule`. Use it when your code needs this specific behavior from the package. |

