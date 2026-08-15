# GetBytes

[Back to IranSystemEncoding](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.IranSystem](../../index.md)

Source: [src/IranSystem/IranSystemEncoding.cs:84](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/IranSystem/IranSystemEncoding.cs#L84)

Type: `KamiSama.IranSystem.IranSystemEncoding`

Kind: `Method`

## Description

Encodes every character in the supplied string using the Iran System character-to-byte table. Each input character produces exactly one output byte.

## Declaration

```csharp
public override byte[] GetBytes(string str);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `str` | `string` | `-` | The string containing ASCII or mapped Persian presentation-form characters to encode. |

## Returns

| Type | Description |
| --- | --- |
| `byte[]` | An array containing one Iran System byte for each input character. |

## Remarks

Characters absent from the mapping, including normalized Persian letters and the null character, are emitted as `0xFF`. The `0xFF` byte decodes as a non-breaking space and is not a round-trip replacement marker.

## Example

No concise standalone example is available yet.

