# KamiSama.Extensions.NLog

[Back to package index](../index.md)

Version: `10.0.0`

## Description

Provides three NLog layout renderers for Persian-calendar timestamps and an IFileCompressor implementation for creating password-protected ZIP archives through SharpZipLib. Use it with the surrounding package APIs when composing application code.

## How to use

```shell
dotnet add package KamiSama.Extensions.NLog --version 10.0.0
```

Register the extension assembly in `NLog.config`, then select the renderer that matches the required timestamp shape:

```xml
<nlog>
  <extensions>
    <add assembly="KamiSama.Extensions.NLog" />
  </extensions>
  <targets>
    <target xsi:type="File" name="file" fileName="${baseDir}/app.log"
            layout="${persian-date:format=yyyy/MM/dd HH\:mm\:ss.fff} ${message}" />
  </targets>
</nlog>
```

The available renderer names are `persian-date`, `persian-longDate`, and `persian-shortDate`. To password-protect archives, assign the NLog file compressor in application startup:

```csharp
using KamiSama.Extensions.NLog;
using NLog.Targets;

string archivePassword = Environment.GetEnvironmentVariable("NLOG_ARCHIVE_PASSWORD")
    ?? throw new InvalidOperationException("NLOG_ARCHIVE_PASSWORD is not configured.");

PasswordFunc passwordFunc = (fileName, archiveFileName) => archivePassword;
ConcurrentFileTarget.FileCompressor = new EncryptedZipArchiveFileCompressor(passwordFunc);
```

Resolve archive passwords from a secret store or protected configuration. Never hardcode them in source code or `NLog.config`.

## Namespaces

- [KamiSama.Extensions.NLog](kamisama-extensions-nlog/index.md) (5 types)

## Types

- [KamiSama.Extensions.NLog.EncryptedZipArchiveFileCompressor](kamisama-extensions-nlog/kamisama-extensions-nlog-encryptedziparchivefilecompressor/index.md) - Implements NLog archive compression by adding log files to password-protected ZIP archives with SharpZipLib. Assign an instance to `ConcurrentFileTarget.FileCompressor` when encrypted archive entries are required.
- [KamiSama.Extensions.NLog.PasswordFunc](kamisama-extensions-nlog/kamisama-extensions-nlog-passwordfunc/index.md) - Resolves the password used when a log file is added to a ZIP archive. Use it with the surrounding package APIs when composing application code.
- [KamiSama.Extensions.NLog.PersianDateLayoutRenderer](kamisama-extensions-nlog/kamisama-extensions-nlog-persiandatelayoutrenderer/index.md) - Renders an NLog event timestamp with a configurable Persian-calendar date and time format. Use `Format` to select the output accepted by the Persian date formatting extensions.
- [KamiSama.Extensions.NLog.PersianLongDateLayoutRenderer](kamisama-extensions-nlog/kamisama-extensions-nlog-persianlongdatelayoutrenderer/index.md) - Renders an NLog event timestamp as a Persian-calendar date with time and four fractional-second digits. The fixed output format is `yyyy-MM-dd HH:mm:ss.ffff`.
- [KamiSama.Extensions.NLog.PersianShortDateLayoutRenderer](kamisama-extensions-nlog/kamisama-extensions-nlog-persianshortdatelayoutrenderer/index.md) - Renders the date portion of an NLog event timestamp using the Persian calendar. The fixed output format is `yyyy-MM-dd`.
