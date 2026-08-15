# GetBytes

[Back to IranSystemEncoding](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.IranSystem](../../index.md)

Source: [src/IranSystem/IranSystemEncoding.cs:123](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/IranSystem/IranSystemEncoding.cs#L123)

Type: `KamiSama.IranSystem.IranSystemEncoding`

Kind: `Method`

## Description

Returns the requested character count without encoding or writing to the destination byte array. Do not use this overload when output bytes are required.

## Declaration

```csharp
public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `chars` | `char[]` | `-` | The character array that is currently not read. |
| `charIndex` | `int` | `-` | The nominal starting index in `chars`. |
| `charCount` | `int` | `-` | The number returned as though that many characters had been encoded. |
| `bytes` | `byte[]` | `-` | The destination array that is currently left unchanged. |
| `byteIndex` | `int` | `-` | The nominal starting index in `bytes`. |

## Returns

| Type | Description |
| --- | --- |
| `int` | The supplied `charCount` value, although no bytes are written. |

## Remarks

This overload currently reports success without reading, validating, encoding, or writing any data.

## Example

No concise standalone example is available yet.

