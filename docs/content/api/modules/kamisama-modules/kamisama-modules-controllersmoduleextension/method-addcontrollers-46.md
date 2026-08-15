# AddControllers

[Back to ControllersModuleExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/ControllersModule.cs:46](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ControllersModule.cs#L46)

Type: `KamiSama.Modules.ControllersModuleExtension`

Kind: `Method`

## Description

Queues controller service registration and endpoint mapping. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddControllers(this ExtendedWebApplicationBuilder builder, Action<IMvcBuilder>? configure = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The builder that receives the module. |
| `configure` | `Action<IMvcBuilder>?` | `null` | An optional callback for the MVC builder. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | The same builder for fluent composition. |

## Example

```csharp
using KamiSama.Modules;

var builder = WebApplication.CreateBuilder(args).Extend().AddControllers();
```

