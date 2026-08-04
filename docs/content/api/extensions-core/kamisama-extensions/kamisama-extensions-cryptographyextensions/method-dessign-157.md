# DesSign

[Back to CryptographyExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/CryptographyExtensions.cs:157](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/CryptographyExtensions.cs#L157)

Type: `KamiSama.Extensions.CryptographyExtensions`

Kind: `Method`

## Description

Signs (MAC) for data using DES algorithm. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static byte[] DesSign(this byte[] data, byte[] key, byte[]? iv = null, PaddingMode padding = PaddingMode.Zeros);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `data (extension receiver)` | `byte[]` | `-` | the byte data to be signed |
| `key` | `byte[]` | `-` | the encryption key |
| `iv` | `byte[]?` | `null` | initial value |
| `padding` | `PaddingMode` | `PaddingMode.Zeros` | padding mode, such as none, zeros, pkcs5... |

## Returns

| Type | Description |
| --- | --- |
| `byte[]` | Returns a `byte[]` value. |

## Example

```csharp
var data = "01020304050607080102030405060708090A".FromHex();
var key = "0001020304050607".FromHex();

data = data.Pad(len => len % 8 == 0);

var encrypted = data
.DesEncrypt(key, cipherMode: CipherMode.CBC, padding: PaddingMode.Zeros);

var result = "6ACC204F8EFBCCC7A2099E1EEB445D9A9FBC1B9AC763E51B".FromHex();


var decrypted = result
.DesDecrypt(key,  cipherMode: CipherMode.CBC, padding: PaddingMode.None);


var sign = data.DesSign(key);
```

