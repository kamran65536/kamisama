# StringExtensions

<a id="stringextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Core/StringExtensions.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/StringExtensions.cs#L7)

Namespace: `KamiSama.Extensions`

Kind: `Class`

## Description

Provides extensions for encoding strings and decoding hexadecimal and Base64 text. Use them to move between textual representations and byte arrays.

## Declaration

```csharp
public static class StringExtensions
```

## Example

```csharp
byte[] bytes = "KamiSama".ToBytes();
byte[] hexBytes = "CAFE".FromHex();
byte[] base64Bytes = "S2FtaVNhbWE=".FromBase64();
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [FromBase64](method-frombase64-53.md) | Converts base 64 string to byte array. Use it with the surrounding package APIs when composing application code. |
| [FromHex](method-fromhex-22.md) | Converts hexadecimal string to byte array. Use it with the surrounding package APIs when composing application code. |
| [ToBytes](method-tobytes-15.md) | Converts string to byte array using specified encoding. Use it with the surrounding package APIs when composing application code. |

