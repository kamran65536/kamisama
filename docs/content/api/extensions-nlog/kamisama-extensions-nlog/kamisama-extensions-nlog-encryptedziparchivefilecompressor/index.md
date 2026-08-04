# EncryptedZipArchiveFileCompressor

<a id="encryptedziparchivefilecompressor"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.NLog](../../index.md) | [Back to package index](../../../index.md)

Source: [src/NLog/EncryptedZipArchiveFileCompressor.cs:23](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/NLog/EncryptedZipArchiveFileCompressor.cs#L23)

Namespace: `KamiSama.Extensions.NLog`

Kind: `Class`

## Description

Encrypted Zip Archive inspired by NLog ZipArchiveFileCompressor. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class EncryptedZipArchiveFileCompressor(PasswordFunc passwordFunc, CompressionMethod compressionMethod = CompressionMethod.BZip2) : IFileCompressor
```

## Remarks

constructor

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/NLog/EncryptedZipArchiveFileCompressor.cs#L23)

Encrypted Zip Archive inspired by NLog ZipArchiveFileCompressor. Use it with the surrounding package APIs when composing application code.

```csharp
public class EncryptedZipArchiveFileCompressor(PasswordFunc passwordFunc, CompressionMethod compressionMethod = CompressionMethod.BZip2) : IFileCompressor
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `passwordFunc` | `PasswordFunc` | `-` | password based on current file name |
| `compressionMethod` | `CompressionMethod` | `CompressionMethod.BZip2` | Compression method used by SharpZipLib library |

## Members

### Methods

| Member | Description |
| --- | --- |
| [CompressFile](method-compressfile-31.md) | Implements `IFileCompressor.CompressFile(string, string)` using the .Net4.5 specific `System.IO.Compression.ZipArchive`. Use it with the surrounding package APIs when composing application code. |

