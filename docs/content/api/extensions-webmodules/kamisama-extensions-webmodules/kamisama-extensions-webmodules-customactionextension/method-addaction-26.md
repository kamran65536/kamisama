# AddAction

[Back to CustomActionExtension](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md)

Source: [src/KamiSama.Extensions.WebModules/CustomActionModule.cs:26](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/CustomActionModule.cs#L26)

Type: `KamiSama.Extensions.WebModules.CustomActionExtension`

Kind: `Method`

## Description

Adds custom action module. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static ExtendedWebApplicationBuilder AddAction(this ExtendedWebApplicationBuilder builder, Action<WebApplication> action, bool condition = true);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `builder (extension receiver)` | `ExtendedWebApplicationBuilder` | `-` | The `builder` value passed to this member. |
| `action` | `Action<WebApplication>` | `-` | The `action` value passed to this member. |
| `condition` | `bool` | `true` | The `condition` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | Returns a `ExtendedWebApplicationBuilder` value. |

## Example

No concise standalone example is available yet.

