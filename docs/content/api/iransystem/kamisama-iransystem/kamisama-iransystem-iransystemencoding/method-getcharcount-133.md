# GetCharCount

[Back to IranSystemEncoding](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.IranSystem](../../index.md)

Source: [src/IranSystem/IranSystemEncoding.cs:133](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/IranSystem/IranSystemEncoding.cs#L133)

Type: `KamiSama.IranSystem.IranSystemEncoding`

Kind: `Method`

## Description

Returns the requested byte count because this encoding maps each byte to one character. This method reports the supplied count without examining the requested range.

## Declaration

```csharp
public override int GetCharCount(byte[] bytes, int index, int count);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `bytes` | `byte[]` | `-` | The byte array that would be measured. |
| `index` | `int` | `-` | The nominal starting index in `bytes`. |
| `count` | `int` | `-` | The number of bytes requested. |

## Returns

| Type | Description |
| --- | --- |
| `int` | The supplied `count` value. |

## Remarks

The current implementation does not inspect the array, index, or byte values.

## Example

No concise standalone example is available yet.

