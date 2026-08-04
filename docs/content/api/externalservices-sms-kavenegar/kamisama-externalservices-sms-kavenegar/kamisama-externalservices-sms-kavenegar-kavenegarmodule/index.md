# KavenegarModule

<a id="kavenegarmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.Kavenegar](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.Kavenegar/KavenegarModule.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Kavenegar/KavenegarModule.cs#L9)

Namespace: `KamiSama.ExternalServices.Sms.Kavenegar`

Kind: `Class`

## Description

ASP.NET Core web-module implementation for `KavenegarModule`. Add it through the extended web application builder to register services and apply the related middleware or endpoints.

## Declaration

```csharp
internal class KavenegarModule(IConfigurationSection kavenegarSection) : WebModule
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Kavenegar/KavenegarModule.cs#L9)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
internal class KavenegarModule(IConfigurationSection kavenegarSection) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `kavenegarSection` | `IConfigurationSection` | `-` | The `kavenegarSection` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-17.md) | Runs the `ApplyConfigurationToAsync` operation on `KavenegarModule`. Use it when your code needs this specific behavior from the package. |
| [ConfigureServices](method-configureservices-11.md) | Runs the `ConfigureServices` operation on `KavenegarModule`. Use it when your code needs this specific behavior from the package. |

