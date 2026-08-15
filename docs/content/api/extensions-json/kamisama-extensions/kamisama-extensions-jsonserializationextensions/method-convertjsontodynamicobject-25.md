# ConvertJsonToDynamicObject

[Back to JsonSerializationExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md)

Source: [src/Json/JsonSerializationExtensions.cs:25](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/JsonSerializationExtensions.cs#L25)

Type: `KamiSama.Extensions.JsonSerializationExtensions`

Kind: `Method`

## Description

Converts a JSON element to an `ExpandoObject`, object array, scalar CLR value, or . Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static object? ConvertJsonToDynamicObject(this JsonElement element);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `element (extension receiver)` | `JsonElement` | `-` | The `element` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `object?` | Returns a `object?` value. |

## Example

```csharp
var str = @"{ ""x"" : 10.0, ""y"": { ""a"" : ""kamran""}, ""z"" : [ 1.1, 2, null, true, false ]}";

dynamic d = str.ConvertJsonToDynamicObject(opt => opt.MaxDepth = 100)!;
```

