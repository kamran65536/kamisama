# Decrypt

[Back to CryptographyExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/CryptographyExtensions.cs:54](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/CryptographyExtensions.cs#L54)

Type: `KamiSama.Extensions.CryptographyExtensions`

Kind: `Method`

## Description

Decrypts cipher data using the specified algorithm. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static byte[] Decrypt(this byte[] cipher, SymmetricAlgorithm algorithm);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cipher (extension receiver)` | `byte[]` | `-` | the cipher data |
| `algorithm` | `SymmetricAlgorithm` | `-` | the decryption algorithm |

## Returns

| Type | Description |
| --- | --- |
| `byte[]` | Returns a `byte[]` value. |

## Example

No concise standalone example is available yet.

