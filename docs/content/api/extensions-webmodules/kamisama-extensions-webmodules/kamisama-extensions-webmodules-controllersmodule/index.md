# ControllersModule

<a id="controllersmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Extensions.WebModules/ControllersModule.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/ControllersModule.cs#L7)

Namespace: `KamiSama.Extensions.WebModules`

Kind: `Class`

## Description

ASP.NET Core web-module implementation for `ControllersModule`. Add it through the extended web application builder to register services and apply the related middleware or endpoints.

## Declaration

```csharp
public class ControllersModule(Action<IMvcBuilder>? configure) : WebModule
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/ControllersModule.cs#L7)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public class ControllersModule(Action<IMvcBuilder>? configure) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `configure` | `Action<IMvcBuilder>?` | `-` | The `configure` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-17.md) | Runs the `ApplyConfigurationToAsync` operation on `ControllersModule`. Use it when your code needs this specific behavior from the package. |
| [ConfigureMvcBuilder](method-configuremvcbuilder-26.md) | Configures the mvc builder for inheritance. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-10.md) | Runs the `ConfigureServices` operation on `ControllersModule`. Use it when your code needs this specific behavior from the package. |

