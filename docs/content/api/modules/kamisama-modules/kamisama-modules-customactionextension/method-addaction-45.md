# AddAction

[Back to CustomActionExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/CustomActionModule.cs:45](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/CustomActionModule.cs#L45)

Type: `KamiSama.Modules.CustomActionExtension`

Kind: `Method`

## Description

Queues an asynchronous application action in a `CustomActionModule`. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddAction(this ExtendedWebApplicationBuilder builder, Func<WebApplication, Task> action, bool condition = true);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The builder that receives the module. |
| `action` | `Func<WebApplication, Task>` | `-` | The asynchronous action to invoke after build. |
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

