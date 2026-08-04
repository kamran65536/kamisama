# SmsCoreServicesModule

<a id="smscoreservicesmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.Core/SmsCoreServicesModule.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Core/SmsCoreServicesModule.cs#L9)

Namespace: `KamiSama.ExternalServices.Sms`

Kind: `Class`

## Description

ASP.NET Core web-module implementation for `SmsCoreServicesModule`. Add it through the extended web application builder to register services and apply the related middleware or endpoints.

## Declaration

```csharp
public class SmsCoreServicesModule(IConfigurationSection defaultsSection) : WebModule
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Core/SmsCoreServicesModule.cs#L9)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public class SmsCoreServicesModule(IConfigurationSection defaultsSection) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `defaultsSection` | `IConfigurationSection` | `-` | The `defaultsSection` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-17.md) | Runs the `ApplyConfigurationToAsync` operation on `SmsCoreServicesModule`. Use it when your code needs this specific behavior from the package. |
| [ConfigureServices](method-configureservices-11.md) | Runs the `ConfigureServices` operation on `SmsCoreServicesModule`. Use it when your code needs this specific behavior from the package. |

