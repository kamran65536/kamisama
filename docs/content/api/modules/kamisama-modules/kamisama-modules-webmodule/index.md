# WebModule

<a id="webmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules/WebModule.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/WebModule.cs#L7)

Namespace: `KamiSama.Modules`

Kind: `Class`

## Description

Base abstraction for modular ASP.NET Core setup. Implement it when a feature area needs to register services before build and apply middleware or endpoints after build.

## Declaration

```csharp
public abstract class WebModule
```

## Example

```csharp
using KamiSama.Modules;

public sealed class ProductsModule : WebModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
    }

    public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
    {
        app.MapGet("/products", () => Results.Ok());
        return Task.CompletedTask;
    }
}
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-24.md) | Applies middleware, endpoint mapping, or post-build application configuration after the app is built. |
| [ConfigureServices](method-configureservices-17.md) | Registers services before `WebApplicationBuilder.Build` runs. Override it for DI, MVC, options, authentication, and other service registrations. |

### Properties

| Member | Description |
| --- | --- |
| [Builder](property-builder-12.md) | Optional reference to the extended web application builder that owns this module. |

