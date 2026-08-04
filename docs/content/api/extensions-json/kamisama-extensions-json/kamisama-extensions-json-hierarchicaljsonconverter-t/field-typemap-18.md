# typeMap

[Back to HierarchicalJsonConverter<T>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Json](../../index.md)

Source: [src/Json/HirerarchialJsonConverter.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Json/HirerarchialJsonConverter.cs#L18)

Type: `KamiSama.Extensions.Json.HierarchicalJsonConverter<T>`

Kind: `Field`

## Description

map from discriminator key value to child type. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
internal static readonly Dictionary<string, Type> typeMap = new(StringComparer.InvariantCultureIgnoreCase);
```

## Value

| Detail | Description |
| --- | --- |
| `Field` | Stores a `Dictionary<string, Type>` value. |

## Example

No concise standalone example is available yet.

