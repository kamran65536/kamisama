# CompressFile

[Back to EncryptedZipArchiveFileCompressor](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.NLog](../../index.md)

Source: [src/NLog/EncryptedZipArchiveFileCompressor.cs:31](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/NLog/EncryptedZipArchiveFileCompressor.cs#L31)

Type: `KamiSama.Extensions.NLog.EncryptedZipArchiveFileCompressor`

Kind: `Method`

## Description

Implements `IFileCompressor.CompressFile(string, string)` using the .Net4.5 specific `System.IO.Compression.ZipArchive`. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public void CompressFile(string fileName, string archiveFileName);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `fileName` | `string` | `-` | The `fileName` value passed to this member. |
| `archiveFileName` | `string` | `-` | The `archiveFileName` value passed to this member. |

## Example

No concise standalone example is available yet.

