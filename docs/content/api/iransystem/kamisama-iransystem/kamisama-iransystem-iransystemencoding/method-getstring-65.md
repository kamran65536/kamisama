# GetString

[Back to IranSystemEncoding](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.IranSystem](../../index.md)

Source: [src/IranSystem/IranSystemEncoding.cs:65](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/IranSystem/IranSystemEncoding.cs#L65)

Type: `KamiSama.IranSystem.IranSystemEncoding`

Kind: `Method`

## Description

Decodes every byte in the supplied array using the Iran System byte-to-character table. Each input byte produces exactly one output character.

## Declaration

```csharp
public override string GetString(byte[] bytes);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `bytes` | `byte[]` | `-` | The complete Iran System byte sequence to decode. |

## Returns

| Type | Description |
| --- | --- |
| `string` | A string containing ASCII characters or the mapped Persian glyph presentation forms. |

## Example

```csharp
var arr = "012"u8.ToArray();

var str = arr.GetString();
```

