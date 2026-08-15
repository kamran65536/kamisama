# IranSystemEncoding

<a id="iransystemencoding"></a>

[Back to namespace](../index.md) | [Back to KamiSama.IranSystem](../../index.md) | [Back to package index](../../../index.md)

Source: [src/IranSystem/IranSystemEncoding.cs:20](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/IranSystem/IranSystemEncoding.cs#L20)

Namespace: `KamiSama.IranSystem`

Kind: `Class`

## Description

A `System.Text.Encoding` implementation for converting between legacy single-byte Iran System data and Unicode characters. Use its complete-buffer string methods when exchanging data with legacy Persian systems.

## Declaration

```csharp
public class IranSystemEncoding : Encoding
```

## Remarks

Iran System stores contextual Persian glyph shapes. Decoding therefore produces Arabic presentation-form characters, and encoding expects those exact presentation-form code points rather than normalized Persian text.

## Example

```csharp
using KamiSama.IranSystem;

var encoding = new IranSystemEncoding();
string text = encoding.GetString(new byte[] { 0x80, 0x81, 0x82 });
byte[] bytes = encoding.GetBytes(text);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [GetByteCount](method-getbytecount-111.md) | Returns the requested character count because this encoding uses one byte per character. This method reports the supplied count without examining the requested range. |
| [GetBytes](method-getbytes-84.md) | Encodes every character in the supplied string using the Iran System character-to-byte table. Each input character produces exactly one output byte. |
| [GetBytes](method-getbytes-123.md) | Returns the requested character count without encoding or writing to the destination byte array. Do not use this overload when output bytes are required. |
| [GetCharCount](method-getcharcount-133.md) | Returns the requested byte count because this encoding maps each byte to one character. This method reports the supplied count without examining the requested range. |
| [GetChars](method-getchars-145.md) | Returns the requested byte count without decoding or writing to the destination character array. Do not use this overload when output characters are required. |
| [GetMaxByteCount](method-getmaxbytecount-152.md) | Returns the supplied character count as the maximum byte count for this single-byte encoding. No fallback expansion is included in the result. |
| [GetMaxCharCount](method-getmaxcharcount-159.md) | Returns the supplied byte count as the maximum character count for this single-byte encoding. Every encoded byte corresponds to one table entry. |
| [GetString](method-getstring-65.md) | Decodes every byte in the supplied array using the Iran System byte-to-character table. Each input byte produces exactly one output character. |

