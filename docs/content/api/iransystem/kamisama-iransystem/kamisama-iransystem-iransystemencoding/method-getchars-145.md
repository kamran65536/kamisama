# GetChars

[Back to IranSystemEncoding](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.IranSystem](../../index.md)

Source: [src/IranSystem/IranSystemEncoding.cs:145](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/IranSystem/IranSystemEncoding.cs#L145)

Type: `KamiSama.IranSystem.IranSystemEncoding`

Kind: `Method`

## Description

Returns the requested byte count without decoding or writing to the destination character array. Do not use this overload when output characters are required.

## Declaration

```csharp
public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `bytes` | `byte[]` | `-` | The byte array that is currently not read. |
| `byteIndex` | `int` | `-` | The nominal starting index in `bytes`. |
| `byteCount` | `int` | `-` | The number returned as though that many bytes had been decoded. |
| `chars` | `char[]` | `-` | The destination array that is currently left unchanged. |
| `charIndex` | `int` | `-` | The nominal starting index in `chars`. |

## Returns

| Type | Description |
| --- | --- |
| `int` | The supplied `byteCount` value, although no characters are written. |

## Remarks

This overload currently reports success without reading, validating, decoding, or writing any data.

## Example

No concise standalone example is available yet.

