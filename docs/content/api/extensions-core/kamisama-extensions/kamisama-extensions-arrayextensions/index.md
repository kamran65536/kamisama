# ArrayExtensions

<a id="arrayextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Core/ArrayExtensions.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/ArrayExtensions.cs#L7)

Namespace: `KamiSama.Extensions`

Kind: `Class`

## Description

Provides extension methods for padding arrays and removing matching trailing elements. Use these helpers when an array must be resized or normalized without mutating the original instance.

## Declaration

```csharp
public static class ArrayExtensions
```

## Example

```csharp
int[] values = [1, 2];
int[] padded = values.Pad(4, 0);       // [1, 2, 0, 0]
int[] trimmed = padded.TrimEnd(0);     // [1, 2]
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [Pad<TArrayItem>](method-pad-tarrayitem-17.md) | Returns an array padded to the first length that satisfies the specified predicate. Use it with the surrounding package APIs when composing application code. |
| [Pad<TArrayItem>](method-pad-tarrayitem-34.md) | Returns an array padded to the specified length. Use it with the surrounding package APIs when composing application code. |
| [TrimEnd<TArrayItem>](method-trimend-tarrayitem-57.md) | Returns an array with consecutive trailing elements that satisfy the predicate removed. Use it with the surrounding package APIs when composing application code. |
| [TrimEnd<TArrayItem>](method-trimend-tarrayitem-80.md) | Returns an array with consecutive trailing elements equal to the specified value removed. Use it with the surrounding package APIs when composing application code. |

