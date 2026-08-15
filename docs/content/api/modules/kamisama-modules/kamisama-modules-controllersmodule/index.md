# ControllersModule

<a id="controllersmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules/ControllersModule.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ControllersModule.cs#L8)

Namespace: `KamiSama.Modules`

Kind: `Class`

## Description

Registers MVC controllers, supports MVC-builder customization, and maps controller endpoints after build. Use the callback or a derived override to customize registration.

## Declaration

```csharp
public class ControllersModule(Action<IMvcBuilder>? configure) : WebModule
```

## Example

```csharp
var builder = webBuilder.Extend()
    .AddModule(new ControllersModule(mvc => mvc.AddApplicationPart(typeof(Program).Assembly)));
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ControllersModule.cs#L8)

Registers MVC controllers, optionally customizes the resulting MVC builder, and maps controller endpoints after build. Use it with the surrounding package APIs when composing application code.

```csharp
public class ControllersModule(Action<IMvcBuilder>? configure) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `configure` | `Action<IMvcBuilder>?` | `-` | An optional callback invoked after `AddControllers` returns its MVC builder. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-22.md) | Maps attribute-routed controller endpoints at this module&apos;s position in post-build order. Use it with the surrounding package APIs when composing application code. |
| [ConfigureMvcBuilder](method-configuremvcbuilder-32.md) | Invokes the constructor callback for the MVC builder; derived modules can override this hook to add controller conventions or features. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-12.md) | Calls `AddControllers` and passes the resulting builder to `ConfigureMvcBuilder`. Use it with the surrounding package APIs when composing application code. |

