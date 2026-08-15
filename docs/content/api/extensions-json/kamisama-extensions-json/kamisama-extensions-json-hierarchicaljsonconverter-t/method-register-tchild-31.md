# Register<TChild>

[Back to HierarchicalJsonConverter<T>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md)

Source: [src/Json/HirerarchialJsonConverter.cs:31](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/HirerarchialJsonConverter.cs#L31)

Type: `KamiSama.Extensions.Json.HierarchicalJsonConverter<T>`

Kind: `Method`

## Description

Registers &lt;typeparamref name=&quot;TChild&quot;/&gt; using the discriminator value obtained from a newly constructed instance. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static void Register<TChild>()
    where TChild : T, new();
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TChild` |  |

## Parameters

This member does not declare parameters.

## Example

No concise standalone example is available yet.

