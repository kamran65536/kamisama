# 6. KamiSama.Extensions.NLog
This library adds Persian-calendar timestamp renderers and password-protected ZIP archive compression to [NLog](https://nlog-project.org/).
## 6.1. Persian date layout renderers
Register the extension assembly in `NLog.config`, then use `persian-date`, `persian-longDate`, or `persian-shortDate` in a layout:
```xml
<nlog>
    <extensions>
        <add assembly="KamiSama.Extensions.NLog" />
    </extensions>
    <targets>
        <target xsi:type="File" name="file" fileName="${baseDir}/now.log" layout="${persian-date:format=yyyy/MM/dd HH\:mm\:ss.fff} ${message}" />
    </targets>
    <rules>
        <logger name="*" minlevel="Trace" writeTo="file" />
    </rules>
</nlog>
```
## 6.2. EncryptedZipArchiveFileCompressor
`EncryptedZipArchiveFileCompressor` implements NLog's `IFileCompressor` with [SharpZipLib](https://github.com/icsharpcode/SharpZipLib) so archived log entries can be password protected.
Assign the compressor programmatically and resolve its password from secure configuration. Never hardcode archive passwords in source code or `NLog.config`:
```csharp
using KamiSama.Extensions.NLog;
using NLog.Targets;

string archivePassword = Environment.GetEnvironmentVariable("NLOG_ARCHIVE_PASSWORD")
    ?? throw new InvalidOperationException("NLOG_ARCHIVE_PASSWORD is not configured.");

PasswordFunc passwordFunc = (fileName, archiveFileName) => archivePassword;
ConcurrentFileTarget.FileCompressor = new EncryptedZipArchiveFileCompressor(passwordFunc);
```
