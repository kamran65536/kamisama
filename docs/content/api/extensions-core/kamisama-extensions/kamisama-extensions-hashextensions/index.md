# HashExtensions

<a id="hashextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Core/HashExtensions.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/HashExtensions.cs#L7)

Namespace: `KamiSama.Extensions`

Kind: `Class`

## Description

Provides hash-computation helpers for byte arrays and strings, including hexadecimal MD5 and SHA-1 output. Prefer a modern hash algorithm for new security-sensitive applications.

## Declaration

```csharp
public static class HashExtensions
```

## Example

```csharp
using System.Security.Cryptography;

using var sha256 = SHA256.Create();
string digest = "message".ComputeHashHex(sha256);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ComputeHash](method-computehash-19.md) | Computes the hash of the byte array using the specified algorithm. Use it with the surrounding package APIs when composing application code. |
| [ComputeHash](method-computehash-36.md) | Encodes the string and computes its hash using the specified algorithm. Use it with the surrounding package APIs when composing application code. |
| [ComputeHashHex](method-computehashhex-27.md) | Computes the hash of the byte array and returns it as an uppercase hexadecimal string. Use it with the surrounding package APIs when composing application code. |
| [ComputeHashHex](method-computehashhex-45.md) | Encodes the string, computes its hash, and returns the result as an uppercase hexadecimal string. Use it with the surrounding package APIs when composing application code. |
| [GetMd5](method-getmd5-54.md) | Computes the MD5 hash of the byte array. Use it with the surrounding package APIs when composing application code. |
| [GetMd5](method-getmd5-69.md) | Encodes the string and computes its MD5 hash. Use it with the surrounding package APIs when composing application code. |
| [GetMd5Hex](method-getmd5hex-61.md) | Computes the MD5 hash of the byte array and returns it as an uppercase hexadecimal string. Use it with the surrounding package APIs when composing application code. |
| [GetMd5Hex](method-getmd5hex-77.md) | Encodes the string and returns its MD5 hash as an uppercase hexadecimal string. Use it with the surrounding package APIs when composing application code. |
| [GetSha1](method-getsha1-86.md) | Computes the SHA-1 hash of the byte array. Use it with the surrounding package APIs when composing application code. |
| [GetSha1](method-getsha1-100.md) | Encodes the string and computes its SHA-1 hash. Use it with the surrounding package APIs when composing application code. |
| [GetSha1Hex](method-getsha1hex-92.md) | Computes the SHA-1 hash of the byte array and returns it as an uppercase hexadecimal string. Use it with the surrounding package APIs when composing application code. |
| [GetSha1Hex](method-getsha1hex-108.md) | Encodes the string and returns its SHA-1 hash as an uppercase hexadecimal string. Use it with the surrounding package APIs when composing application code. |

