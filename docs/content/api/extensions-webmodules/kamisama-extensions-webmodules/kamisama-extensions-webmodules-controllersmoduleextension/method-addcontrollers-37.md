# AddControllers

[Back to ControllersModuleExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md)

Source: [src/KamiSama.Extensions.WebModules/ControllersModule.cs:37](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/ControllersModule.cs#L37)

Type: `KamiSama.Extensions.WebModules.ControllersModuleExtension`

Kind: `Method`

## Description

Adds Api controller configuration. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddControllers(this ExtendedWebApplicationBuilder builder, Action<IMvcBuilder>? configure = null);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The `builder` value passed to this member. |
| `configure` | `Action<IMvcBuilder>?` | `null` | The `configure` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | Returns a `ExtendedWebApplicationBuilder` value. |

## Example

```csharp
using KamiSama.Extensions.WebModules;

var builder = WebApplication.CreateBuilder(args).Extend().AddControllers();
```

