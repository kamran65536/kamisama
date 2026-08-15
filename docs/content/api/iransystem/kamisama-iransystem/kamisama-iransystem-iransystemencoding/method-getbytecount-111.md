# GetByteCount

[Back to IranSystemEncoding](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.IranSystem](../../index.md)

Source: [src/IranSystem/IranSystemEncoding.cs:111](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/IranSystem/IranSystemEncoding.cs#L111)

Type: `KamiSama.IranSystem.IranSystemEncoding`

Kind: `Method`

## Description

Returns the requested character count because this encoding uses one byte per character. This method reports the supplied count without examining the requested range.

## Declaration

```csharp
public override int GetByteCount(char[] chars, int index, int count);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `chars` | `char[]` | `-` | The character array that would be measured. |
| `index` | `int` | `-` | The nominal starting index in `chars`. |
| `count` | `int` | `-` | The number of characters requested. |

## Returns

| Type | Description |
| --- | --- |
| `int` | The supplied `count` value. |

## Remarks

The current implementation does not inspect the array, index, or character values.

## Example

No concise standalone example is available yet.

