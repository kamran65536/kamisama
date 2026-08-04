# ComputeHash

[Back to HashExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/HashExtensions.cs:18](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/HashExtensions.cs#L18)

Type: `KamiSama.Extensions.HashExtensions`

Kind: `Method`

## Description

Computes hash for an hashing algorithm. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
#region Generic Hashing
public static byte[] ComputeHash(this byte[] data, HashAlgorithm algorithm);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `data (extension receiver)` | `byte[]` | `-` | the data to be hashed |
| `algorithm` | `HashAlgorithm` | `-` | the hashing algorithm |

## Returns

| Type | Description |
| --- | --- |
| `byte[]` | Returns a `byte[]` value. |

## Example

No concise standalone example is available yet.

