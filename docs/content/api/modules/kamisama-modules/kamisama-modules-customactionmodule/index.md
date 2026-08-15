# CustomActionModule

<a id="customactionmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules/CustomActionModule.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/CustomActionModule.cs#L9)

Namespace: `KamiSama.Modules`

Kind: `Class`

## Description

Conditionally awaits a caller-provided application action during post-build configuration. It ignores the build cancellation token and registers no services.

## Declaration

```csharp
public class CustomActionModule(Func<WebApplication, Task> action, bool condition) : WebModule
```

## Example

```csharp
var builder = webBuilder.Extend()
    .AddModule(new CustomActionModule(app =>
    {
        app.MapGet("/health", () => Results.Ok());
        return Task.CompletedTask;
    }, condition: true));
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/CustomActionModule.cs#L9)

Runs a caller-provided asynchronous application action during the post-build phase when its captured condition is true. Use it with the surrounding package APIs when composing application code.

```csharp
public class CustomActionModule(Func<WebApplication, Task> action, bool condition) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `action` | `Func<WebApplication, Task>` | `-` | The application action to await. |
| `condition` | `bool` | `-` | Whether the action should run. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-20.md) | Awaits the captured action when the captured condition is true; otherwise completes without invoking it. Use it with the surrounding package APIs when composing application code. |
| [ConfigureServices](method-configureservices-13.md) | Performs no service registration. Use it with the surrounding package APIs when composing application code. |

