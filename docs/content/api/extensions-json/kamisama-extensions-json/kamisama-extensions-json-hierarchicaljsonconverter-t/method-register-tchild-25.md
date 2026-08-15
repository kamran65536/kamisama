# Register<TChild>

[Back to HierarchicalJsonConverter<T>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md)

Source: [src/Json/HirerarchialJsonConverter.cs:25](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/HirerarchialJsonConverter.cs#L25)

Type: `KamiSama.Extensions.Json.HierarchicalJsonConverter<T>`

Kind: `Method`

## Description

Associates a discriminator value with the derived type &lt;typeparamref name=&quot;TChild&quot;/&gt;. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static void Register<TChild>(string discriminatorKeyValue)
    where TChild : T;
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TChild` |  |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `discriminatorKeyValue` | `string` | `-` | The `discriminatorKeyValue` value passed to this member. |

## Example

No concise standalone example is available yet.

