# Add

[Back to ExtendedWebApplicationBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/ExtendedWebApplicationBuilder.cs:70](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ExtendedWebApplicationBuilder.cs#L70)

Type: `KamiSama.Modules.ExtendedWebApplicationBuilder`

Kind: `Method`

## Description

Queues an asynchronous action for the post-build phase by wrapping it in `CustomActionModule`. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public ExtendedWebApplicationBuilder Add(Func<WebApplication, Task> action, bool condition = true);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `action` | `Func<WebApplication, Task>` | `-` | The asynchronous action invoked with the built application when &lt;paramref name=&quot;condition&quot;/&gt; is true. |
| `condition` | `bool` | `true` | Whether the action should run during the post-build phase. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | This builder for fluent composition. |

## Example

```csharp
var options = new JsonSerializerOptions();
options.Converters.Add(new BigIntegerJsonConverter());

var x = new BigInteger(100);
var result = x.SerializeToJson(options);
```

