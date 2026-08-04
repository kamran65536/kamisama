# AddHexByteConverter

[Back to JsonSerializationExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md)

Source: [src/Json/JsonSerializationExtensions.cs:164](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/JsonSerializationExtensions.cs#L164)

Type: `KamiSama.Extensions.JsonSerializationExtensions`

Kind: `Method`

## Description

Adds TimeSpanJsonConverter as default converter for json. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static JsonSerializerOptions AddHexByteConverter(this JsonSerializerOptions options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options (extension receiver)` | `JsonSerializerOptions` | `-` | The `options` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `JsonSerializerOptions` | Returns a `JsonSerializerOptions` value. |

## Example

```csharp
var options = new JsonSerializerOptions();

options.AddHexByteConverter();
```

