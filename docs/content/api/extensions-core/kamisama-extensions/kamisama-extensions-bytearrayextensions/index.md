# ByteArrayExtensions

<a id="bytearrayextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Core/ByteArrayExtensions.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/ByteArrayExtensions.cs#L7)

Namespace: `KamiSama.Extensions`

Kind: `Class`

## Description

Provides extension methods for converting byte arrays to text, hexadecimal strings, and Base64 strings. Use them to prepare binary data for display, storage, or transport.

## Declaration

```csharp
public static class ByteArrayExtensions
```

## Example

```csharp
byte[] data = [0xCA, 0xFE];
string hex = data.ToHex("-");          // CA-FE
string base64 = data.ToBase64();
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [GetString](method-getstring-23.md) | Decodes the byte array using the specified encoding, or UTF-8 when no encoding is supplied. Use it with the surrounding package APIs when composing application code. |
| [ToBase64](method-tobase64-30.md) | Converts the byte array to its Base64 string representation. Use it with the surrounding package APIs when composing application code. |
| [ToHex](method-tohex-15.md) | Converts the byte array to an uppercase hexadecimal string, optionally separating each byte. Use it with the surrounding package APIs when composing application code. |

