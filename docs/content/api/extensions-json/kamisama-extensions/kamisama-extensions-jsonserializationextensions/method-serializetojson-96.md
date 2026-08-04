# SerializeToJson

[Back to JsonSerializationExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md)

Source: [src/Json/JsonSerializationExtensions.cs:96](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/JsonSerializationExtensions.cs#L96)

Type: `KamiSama.Extensions.JsonSerializationExtensions`

Kind: `Method`

## Description

Serializes to Json using `JsonSerializer`. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static string SerializeToJson(this object? obj, Action<JsonSerializerOptions>? configure);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `obj (extension receiver)` | `object?` | `-` | The `obj` value passed to this member. |
| `configure` | `Action<JsonSerializerOptions>?` | `-` | The `configure` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `string` | Returns a `string` value. |

## Example

```csharp
var options = new JsonSerializerOptions();
options.Converters.Add(new BigIntegerJsonConverter());

var x = new BigInteger(100);
var result = x.SerializeToJson(options);
```

