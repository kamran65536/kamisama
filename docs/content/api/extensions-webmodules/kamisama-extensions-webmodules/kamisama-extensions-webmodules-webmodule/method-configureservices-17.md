# ConfigureServices

[Back to WebModule](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md)

Source: [src/KamiSama.Extensions.WebModules/WebModule.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/WebModule.cs#L17)

Type: `KamiSama.Extensions.WebModules.WebModule`

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
| `services` | `IServiceCollection` | `-` | The `services` value passed to this member. |

## Example

```csharp
using KamiSama.Extensions.WebModules;

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

