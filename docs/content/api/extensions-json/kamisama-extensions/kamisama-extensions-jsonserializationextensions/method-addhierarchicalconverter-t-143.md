# AddHierarchicalConverter<T>

[Back to JsonSerializationExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md)

Source: [src/Json/JsonSerializationExtensions.cs:143](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/JsonSerializationExtensions.cs#L143)

Type: `KamiSama.Extensions.JsonSerializationExtensions`

Kind: `Method`

## Description

Adds a `HierarchicalJsonConverter{T}` to these serializer options. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static JsonSerializerOptions AddHierarchicalConverter<T>(this JsonSerializerOptions options)
    where T : class;
```

## Type Parameters

| Name | Description |
| --- | --- |
| `T` |  |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options (extension receiver)` | `JsonSerializerOptions` | `-` | The `options` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `JsonSerializerOptions` | Returns a `JsonSerializerOptions` value. |

## Example

No concise standalone example is available yet.

