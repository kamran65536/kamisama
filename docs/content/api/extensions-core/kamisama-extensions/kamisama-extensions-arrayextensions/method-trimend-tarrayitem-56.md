# TrimEnd<TArrayItem>

[Back to ArrayExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/ArrayExtensions.cs:56](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/ArrayExtensions.cs#L56)

Type: `KamiSama.Extensions.ArrayExtensions`

Kind: `Method`

## Description

Trims end of the array with the specified criteria. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static TArrayItem[] TrimEnd<TArrayItem>(this TArrayItem[] arr, Func<TArrayItem, bool> trimmingCriteria);
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TArrayItem` |  |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `arr (extension receiver)` | `TArrayItem[]` | `-` | the array to be trimmed |
| `trimmingCriteria` | `Func<TArrayItem, bool>` | `-` | the criteria for trimming |

## Returns

| Type | Description |
| --- | --- |
| `TArrayItem[]` | Returns a `TArrayItem[]` value. |

## Example

```csharp
using KamiSama.Extensions;

var clean = new[] { 1, 2, 0, 0 }.TrimEnd(x => x == 0);
```

