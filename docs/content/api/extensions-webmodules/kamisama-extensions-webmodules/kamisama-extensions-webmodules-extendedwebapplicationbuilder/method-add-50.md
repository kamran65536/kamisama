# Add

[Back to ExtendedWebApplicationBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md)

Source: [src/KamiSama.Extensions.WebModules/ExtendedWebApplicationBuilder.cs:50](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/ExtendedWebApplicationBuilder.cs#L50)

Type: `KamiSama.Extensions.WebModules.ExtendedWebApplicationBuilder`

Kind: `Method`

## Description

adds a custom action to run. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public ExtendedWebApplicationBuilder Add(Action<WebApplication> action, bool condition = true);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `action` | `Action<WebApplication>` | `-` | The `action` value passed to this member. |
| `condition` | `bool` | `true` | The `condition` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `ExtendedWebApplicationBuilder` | Returns a `ExtendedWebApplicationBuilder` value. |

## Example

```csharp
var options = new JsonSerializerOptions();
options.Converters.Add(new BigIntegerJsonConverter());

var x = new BigInteger(100);
var result = x.SerializeToJson(options);
```

