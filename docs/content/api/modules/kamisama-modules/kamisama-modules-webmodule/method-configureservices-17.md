# ConfigureServices

[Back to WebModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/WebModule.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/WebModule.cs#L17)

Type: `KamiSama.Modules.WebModule`

Kind: `Method`

## Description

Registers services before `WebApplicationBuilder.Build` runs. Override it for DI, MVC, options, authentication, and other service registrations.

## Declaration

```csharp
public abstract void ConfigureServices(IServiceCollection services);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `services` | `IServiceCollection` | `-` | The underlying application&apos;s mutable service collection. |

## Example

```csharp
using KamiSama.Modules;

public sealed class MyModule : WebModule
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
    }

    public override Task ApplyConfigurationToAsync(WebApplication app, CancellationToken cancellationToken)
        => Task.CompletedTask;
}
```

