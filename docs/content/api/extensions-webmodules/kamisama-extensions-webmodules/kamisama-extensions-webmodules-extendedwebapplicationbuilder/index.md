# ExtendedWebApplicationBuilder

<a id="extendedwebapplicationbuilder"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Extensions.WebModules/ExtendedWebApplicationBuilder.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/ExtendedWebApplicationBuilder.cs#L11)

Namespace: `KamiSama.Extensions.WebModules`

Kind: `Class`

## Description

Composable wrapper around `WebApplicationBuilder` that collects web modules and applies them in a predictable build flow.

## Declaration

```csharp
public class ExtendedWebApplicationBuilder(WebApplicationBuilder internalBuilder) : IHostApplicationBuilder
```

## Example

```csharp
using KamiSama.Extensions.WebModules;

var builder = WebApplication.CreateBuilder(args)
    .Extend()
    .AddControllers()
    .AddSwagger();

var app = await builder.BuildAsync(CancellationToken.None);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/ExtendedWebApplicationBuilder.cs#L11)

Extended Host Application concept to add ApplyModule to it. Use it with the surrounding package APIs when composing application code.

```csharp
public class ExtendedWebApplicationBuilder(WebApplicationBuilder internalBuilder) : IHostApplicationBuilder
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `internalBuilder` | `WebApplicationBuilder` | `-` | The `internalBuilder` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [Add](method-add-50.md) | adds a custom action to run. Use it with the surrounding package APIs when composing application code. |
| [Add](method-add-55.md) | adds a custom action to run. Use it with the surrounding package APIs when composing application code. |
| [AddModule](method-addmodule-34.md) | Adds a new web module to be applied. Use it with the surrounding package APIs when composing application code. |
| [AddModule<TModule>](method-addmodule-tmodule-44.md) | Adds a new web module to be applied. Use it with the surrounding package APIs when composing application code. |
| [Build](method-build-85.md) | Runs the `Build` operation on `ExtendedWebApplicationBuilder`. Use it when your code needs this specific behavior from the package. |
| [BuildAsync](method-buildasync-69.md) | Runs the `BuildAsync` operation on `ExtendedWebApplicationBuilder`. Use it when your code needs this specific behavior from the package. |
| [ConfigureContainer<TContainerBuilder>](method-configurecontainer-tcontainerbuilder-14.md) | Runs the `ConfigureContainer<TContainerBuilder>` operation on `ExtendedWebApplicationBuilder`. Use it when your code needs this specific behavior from the package. |
| [ConfigureServices](method-configureservices-60.md) | Runs the `ConfigureServices` operation on `ExtendedWebApplicationBuilder`. Use it when your code needs this specific behavior from the package. |

### Properties

| Member | Description |
| --- | --- |
| [Configuration](property-configuration-19.md) | Exposes the `Configuration` value on `ExtendedWebApplicationBuilder`. Read or set it as part of configuring or using the type. |
| [Environment](property-environment-21.md) | Exposes the `Environment` value on `ExtendedWebApplicationBuilder`. Read or set it as part of configuring or using the type. |
| [Logging](property-logging-23.md) | Exposes the `Logging` value on `ExtendedWebApplicationBuilder`. Read or set it as part of configuring or using the type. |
| [Metrics](property-metrics-26.md) | Exposes the `Metrics` value on `ExtendedWebApplicationBuilder`. Read or set it as part of configuring or using the type. |
| [Properties](property-properties-17.md) | Exposes the `Properties` value on `ExtendedWebApplicationBuilder`. Read or set it as part of configuring or using the type. |
| [Services](property-services-28.md) | Exposes the `Services` value on `ExtendedWebApplicationBuilder`. Read or set it as part of configuring or using the type. |

