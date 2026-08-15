# GetMaxCharCount

[Back to IranSystemEncoding](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.IranSystem](../../index.md)

Source: [src/IranSystem/IranSystemEncoding.cs:159](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/IranSystem/IranSystemEncoding.cs#L159)

Type: `KamiSama.IranSystem.IranSystemEncoding`

Kind: `Method`

## Description

Returns the supplied byte count as the maximum character count for this single-byte encoding. Every encoded byte corresponds to one table entry.

## Declaration

```csharp
public override int GetMaxCharCount(int byteCount);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `byteCount` | `int` | `-` | The number of bytes to size for. |

## Returns

| Type | Description |
| --- | --- |
| `int` | The supplied `byteCount` value. |

## Example

No concise standalone example is available yet.

