# ExtendedWebApplicationBuilder

<a id="extendedwebapplicationbuilder"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules/ExtendedWebApplicationBuilder.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ExtendedWebApplicationBuilder.cs#L11)

Namespace: `KamiSama.Modules`

Kind: `Class`

## Description

Composable wrapper around `WebApplicationBuilder` that collects web modules and applies them in a predictable build flow.

## Declaration

```csharp
public class ExtendedWebApplicationBuilder(WebApplicationBuilder internalBuilder) : IHostApplicationBuilder
```

## Example

```csharp
using KamiSama.Modules;

var builder = WebApplication.CreateBuilder(args)
    .Extend()
    .AddControllers()
    .AddSwagger();

var app = await builder.BuildAsync(CancellationToken.None);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ExtendedWebApplicationBuilder.cs#L11)

Wraps a `WebApplicationBuilder`, queues `WebModule` instances, and runs their service and application phases in insertion order. Use it with the surrounding package APIs when composing application code.

```csharp
public class ExtendedWebApplicationBuilder(WebApplicationBuilder internalBuilder) : IHostApplicationBuilder
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `internalBuilder` | `WebApplicationBuilder` | `-` | The underlying ASP.NET Core builder that owns configuration, logging, services, and the final application build. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [Add](method-add-62.md) | Queues a synchronous action for the post-build phase by wrapping it in `CustomActionModule`. Use it with the surrounding package APIs when composing application code. |
| [Add](method-add-70.md) | Queues an asynchronous action for the post-build phase by wrapping it in `CustomActionModule`. Use it with the surrounding package APIs when composing application code. |
| [AddModule](method-addmodule-41.md) | Assigns this builder to the module and appends the same instance to the ordered module queue. Use it with the surrounding package APIs when composing application code. |
| [AddModule<TModule>](method-addmodule-tmodule-53.md) | Creates a parameterless module, assigns this builder to it, and appends it to the ordered module queue. Use it with the surrounding package APIs when composing application code. |
| [Build](method-build-106.md) | Synchronously executes `BuildAsync` with `CancellationToken.None` and returns its result. Use it with the surrounding package APIs when composing application code. |
| [BuildAsync](method-buildasync-89.md) | Runs every module&apos;s service phase in insertion order, builds the application once, then awaits every module&apos;s application phase in the same order. Use it with the surrounding package APIs when composing application code. |
| [ConfigureContainer<TContainerBuilder>](method-configurecontainer-tcontainerbuilder-19.md) | Delegates service-provider factory and optional container configuration to the underlying host builder. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-77.md) | Invokes a service-registration callback immediately rather than queueing it as a module. Use it with the surrounding package APIs when composing application code. |

### Properties

| Member | Description |
| --- | --- |
| [Configuration](property-configuration-24.md) | Gets the underlying application&apos;s mutable configuration manager. Use it with the surrounding package APIs when composing application code. |
| [Environment](property-environment-26.md) | Gets the host environment selected by the underlying builder. Use it with the surrounding package APIs when composing application code. |
| [Logging](property-logging-28.md) | Gets the underlying logging builder. Use it with the surrounding package APIs when composing application code. |
| [Metrics](property-metrics-31.md) | Gets the underlying metrics builder. Use it with the surrounding package APIs when composing application code. |
| [Properties](property-properties-22.md) | Gets the shared host-builder property dictionary from the underlying builder. Use it with the surrounding package APIs when composing application code. |
| [Services](property-services-33.md) | Gets the service collection that modules configure before application build. Use it with the surrounding package APIs when composing application code. |

