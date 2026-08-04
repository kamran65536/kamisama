# ComputeHashHex

[Back to HashExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/HashExtensions.cs:26](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/HashExtensions.cs#L26)

Type: `KamiSama.Extensions.HashExtensions`

Kind: `Method`

## Description

Computes hash and then converts it to hexadecimal. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static string ComputeHashHex(this byte[] data, HashAlgorithm algorithm);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `data (extension receiver)` | `byte[]` | `-` | the data to be hashed |
| `algorithm` | `HashAlgorithm` | `-` | the hashing algorithm |

## Returns

| Type | Description |
| --- | --- |
| `string` | hexadecimal hashed data |

## Example

No concise standalone example is available yet.

