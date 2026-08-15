# CompressFile

[Back to EncryptedZipArchiveFileCompressor](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.NLog](../../index.md)

Source: [src/NLog/EncryptedZipArchiveFileCompressor.cs:34](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/NLog/EncryptedZipArchiveFileCompressor.cs#L34)

Type: `KamiSama.Extensions.NLog.EncryptedZipArchiveFileCompressor`

Kind: `Method`

## Description

Creates or opens the destination ZIP archive, applies the callback-provided password, and adds the source file with the configured compression method. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public void CompressFile(string fileName, string archiveFileName);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `fileName` | `string` | `-` | The path of the log file to add to the archive. |
| `archiveFileName` | `string` | `-` | The path of the ZIP archive to create or update. |

## Example

No concise standalone example is available yet.

