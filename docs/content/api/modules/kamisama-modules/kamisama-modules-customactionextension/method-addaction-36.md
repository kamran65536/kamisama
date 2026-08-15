# AddAction

[Back to CustomActionExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/CustomActionModule.cs:36](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/CustomActionModule.cs#L36)

Type: `KamiSama.Modules.CustomActionExtension`

Kind: `Method`

## Description

Wraps a synchronous application action in a queued `CustomActionModule`. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddAction(this ExtendedWebApplicationBuilder builder, Action<WebApplication> action, bool condition = true);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The builder that receives the module. |
| `action` | `Action<WebApplication>` | `-` | The action to invoke after build. |
| `condition` | `bool` | `true` | Whether the action should run. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | The same builder for fluent composition. |

## Example

```csharp
ExtendedWebApplicationBuilder builder = webBuilder.Extend()
    .AddAction(app => app.MapGet("/health", () => Results.Ok()));
```

