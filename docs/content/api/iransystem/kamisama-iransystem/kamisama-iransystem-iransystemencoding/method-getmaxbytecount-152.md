# GetMaxByteCount

[Back to IranSystemEncoding](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.IranSystem](../../index.md)

Source: [src/IranSystem/IranSystemEncoding.cs:152](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/IranSystem/IranSystemEncoding.cs#L152)

Type: `KamiSama.IranSystem.IranSystemEncoding`

Kind: `Method`

## Description

Returns the supplied character count as the maximum byte count for this single-byte encoding. No fallback expansion is included in the result.

## Declaration

```csharp
public override int GetMaxByteCount(int charCount);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `charCount` | `int` | `-` | The number of characters to size for. |

## Returns

| Type | Description |
| --- | --- |
| `int` | The supplied `charCount` value. |

## Example

No concise standalone example is available yet.

