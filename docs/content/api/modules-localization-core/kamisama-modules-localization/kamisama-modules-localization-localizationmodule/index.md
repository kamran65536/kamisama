# LocalizationModule

<a id="localizationmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Localization.Core/LocalizationModule.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/LocalizationModule.cs#L11)

Namespace: `KamiSama.Modules.Localization`

Kind: `Class`

## Description

ASP.NET Core web-module implementation for `LocalizationModule`. Add it through the extended web application builder to register services and apply the related middleware or endpoints.

## Declaration

```csharp
public class LocalizationModule(IConfigurationSection moduleSection, string resourcePath) : WebModule
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/LocalizationModule.cs#L11)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public class LocalizationModule(IConfigurationSection moduleSection, string resourcePath) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `moduleSection` | `IConfigurationSection` | `-` | The `moduleSection` value passed to this member. |
| `resourcePath` | `string` | `-` | The `resourcePath` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-27.md) | Runs the `ApplyConfigurationToAsync` operation on `LocalizationModule`. Use it when your code needs this specific behavior from the package. |
| [ConfigureServices](method-configureservices-13.md) | Runs the `ConfigureServices` operation on `LocalizationModule`. Use it when your code needs this specific behavior from the package. |

