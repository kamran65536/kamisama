# ConvertJsonToDynamicObject

[Back to JsonSerializationExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md)

Source: [src/Json/JsonSerializationExtensions.cs:71](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/JsonSerializationExtensions.cs#L71)

Type: `KamiSama.Extensions.JsonSerializationExtensions`

Kind: `Method`

## Description

Parses a JSON string with the specified document options and converts it to a dynamic CLR object graph. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static object? ConvertJsonToDynamicObject(this string jsonStr, JsonDocumentOptions options = default);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `jsonStr (extension receiver)` | `string` | `-` | The `jsonStr` value passed to this member. |
| `options` | `JsonDocumentOptions` | `default` | The `options` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `object?` | Returns a `object?` value. |

## Example

```csharp
var str = @"{ ""x"" : 10.0, ""y"": { ""a"" : ""kamran""}, ""z"" : [ 1.1, 2, null, true, false ]}";

dynamic d = str.ConvertJsonToDynamicObject(opt => opt.MaxDepth = 100)!;
```

