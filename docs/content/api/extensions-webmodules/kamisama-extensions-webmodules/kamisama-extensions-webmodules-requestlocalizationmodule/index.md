# RequestLocalizationModule

<a id="requestlocalizationmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Extensions.WebModules/RequestLocalizationModule.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/RequestLocalizationModule.cs#L8)

Namespace: `KamiSama.Extensions.WebModules`

Kind: `Class`

## Description

Adds Localization to the module. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class RequestLocalizationModule(Action<RequestLocalizationOptions> configure) : WebModule
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/RequestLocalizationModule.cs#L8)

Adds Localization to the module. Use it with the surrounding package APIs when composing application code.

```csharp
public class RequestLocalizationModule(Action<RequestLocalizationOptions> configure) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `configure` | `Action<RequestLocalizationOptions>` | `-` | The `configure` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-17.md) | Runs the `ApplyConfigurationToAsync` operation on `RequestLocalizationModule`. Use it when your code needs this specific behavior from the package. |
| [ConfigureRequestLocalization](method-configurerequestlocalization-26.md) | Configures request localization for inheritance. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-11.md) | Runs the `ConfigureServices` operation on `RequestLocalizationModule`. Use it when your code needs this specific behavior from the package. |

