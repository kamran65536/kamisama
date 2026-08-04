# CustomActionModule

<a id="customactionmodule"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Extensions.WebModules/CustomActionModule.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/CustomActionModule.cs#L7)

Namespace: `KamiSama.Extensions.WebModules`

Kind: `Class`

## Description

Adds custom action module. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class CustomActionModule(Func<WebApplication, Task> action, bool condition) : WebModule
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/CustomActionModule.cs#L7)

Adds custom action module. Use it with the surrounding package APIs when composing application code.

```csharp
public class CustomActionModule(Func<WebApplication, Task> action, bool condition) : WebModule
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `action` | `Func<WebApplication, Task>` | `-` | The `action` value passed to this member. |
| `condition` | `bool` | `-` | The `condition` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ApplyConfigurationToAsync](method-applyconfigurationtoasync-14.md) | Runs the `ApplyConfigurationToAsync` operation on `CustomActionModule`. Use it when your code needs this specific behavior from the package. |
| [ConfigureServices](method-configureservices-10.md) | Runs the `ConfigureServices` operation on `CustomActionModule`. Use it when your code needs this specific behavior from the package. |

