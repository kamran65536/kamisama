# Pad<TArrayItem>

[Back to ArrayExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/ArrayExtensions.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/ArrayExtensions.cs#L16)

Type: `KamiSama.Extensions.ArrayExtensions`

Kind: `Method`

## Description

Pads an array until criteria is meets. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static TArrayItem[] Pad<TArrayItem>(this TArrayItem[] arr, Func<int, bool> paddingCriteria, TArrayItem paddingValue = default !);
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TArrayItem` |  |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `arr (extension receiver)` | `TArrayItem[]` | `-` | the array to be padded |
| `paddingCriteria` | `Func<int, bool>` | `-` | padding criteria |
| `paddingValue` | `TArrayItem` | `default!` | the padding value |

## Returns

| Type | Description |
| --- | --- |
| `TArrayItem[]` | Returns a `TArrayItem[]` value. |

## Example

```csharp
using KamiSama.Extensions;

var block = new byte[] { 1, 2, 3 }.Pad(len => len % 8 == 0, 0);
```

