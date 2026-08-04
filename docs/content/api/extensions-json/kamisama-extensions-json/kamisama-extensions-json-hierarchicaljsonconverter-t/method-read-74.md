# Read

[Back to HierarchicalJsonConverter<T>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md)

Source: [src/Json/HirerarchialJsonConverter.cs:74](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/HirerarchialJsonConverter.cs#L74)

Type: `KamiSama.Extensions.Json.HierarchicalJsonConverter<T>`

Kind: `Method`

## Description

Reads a &lt;typeparamref name=&quot;T&quot;/&gt; from an input json and converts based on key. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `reader (ref)` | `Utf8JsonReader` | `-` | JsonReader |
| `typeToConvert` | `Type` | `-` | The `typeToConvert` value passed to this member. |
| `options` | `JsonSerializerOptions` | `-` | The `options` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `T?` | Returns a `T?` value. |

## Example

No concise standalone example is available yet.

