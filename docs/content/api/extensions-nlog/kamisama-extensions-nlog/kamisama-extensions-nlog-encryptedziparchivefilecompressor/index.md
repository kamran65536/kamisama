# EncryptedZipArchiveFileCompressor

<a id="encryptedziparchivefilecompressor"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.NLog](../../index.md) | [Back to package index](../../../index.md)

Source: [src/NLog/EncryptedZipArchiveFileCompressor.cs:24](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/NLog/EncryptedZipArchiveFileCompressor.cs#L24)

Namespace: `KamiSama.Extensions.NLog`

Kind: `Class`

## Description

Implements NLog archive compression by adding log files to password-protected ZIP archives with SharpZipLib. Assign an instance to `ConcurrentFileTarget.FileCompressor` when encrypted archive entries are required.

## Declaration

```csharp
public class EncryptedZipArchiveFileCompressor(PasswordFunc passwordFunc, CompressionMethod compressionMethod = CompressionMethod.BZip2) : IFileCompressor
```

## Remarks

The password callback runs for each compression request and should obtain secrets from secure configuration.

## Example

```csharp
using KamiSama.Extensions.NLog;
using NLog.Targets;

string password = Environment.GetEnvironmentVariable("NLOG_ARCHIVE_PASSWORD")
    ?? throw new InvalidOperationException("NLOG_ARCHIVE_PASSWORD is not configured.");

PasswordFunc passwordFunc = (fileName, archiveFileName) => password;
ConcurrentFileTarget.FileCompressor = new EncryptedZipArchiveFileCompressor(passwordFunc);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/NLog/EncryptedZipArchiveFileCompressor.cs#L24)

Implements NLog archive compression by adding log files to password-protected ZIP archives with SharpZipLib. Assign an instance to `ConcurrentFileTarget.FileCompressor` when encrypted archive entries are required.

```csharp
public class EncryptedZipArchiveFileCompressor(PasswordFunc passwordFunc, CompressionMethod compressionMethod = CompressionMethod.BZip2) : IFileCompressor
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `passwordFunc` | `PasswordFunc` | `-` | A callback that supplies the password for the source file and destination archive. |
| `compressionMethod` | `CompressionMethod` | `CompressionMethod.BZip2` | The SharpZipLib compression method used for the new archive entry. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [CompressFile](method-compressfile-34.md) | Creates or opens the destination ZIP archive, applies the callback-provided password, and adds the source file with the configured compression method. Use it with the surrounding package APIs when composing application code. |

