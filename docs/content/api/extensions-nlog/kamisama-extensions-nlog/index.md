# KamiSama.Extensions.NLog

[Back to KamiSama.Extensions.NLog](../index.md)

| Type | Kind | Description | Source |
| --- | --- | --- | --- |
| [EncryptedZipArchiveFileCompressor](kamisama-extensions-nlog-encryptedziparchivefilecompressor/index.md) | Class | Implements NLog archive compression by adding log files to password-protected ZIP archives with SharpZipLib. Assign an instance to `ConcurrentFileTarget.FileCompressor` when encrypted archive entries are required. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/NLog/EncryptedZipArchiveFileCompressor.cs#L24) |
| [PasswordFunc](kamisama-extensions-nlog-passwordfunc/index.md) | Delegate | Resolves the password used when a log file is added to a ZIP archive. Use it with the surrounding package APIs when composing application code. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/NLog/EncryptedZipArchiveFileCompressor.cs#L13) |
| [PersianDateLayoutRenderer](kamisama-extensions-nlog-persiandatelayoutrenderer/index.md) | Class | Renders an NLog event timestamp with a configurable Persian-calendar date and time format. Use `Format` to select the output accepted by the Persian date formatting extensions. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/NLog/PersianDateLayoutRenderer.cs#L7) |
| [PersianLongDateLayoutRenderer](kamisama-extensions-nlog-persianlongdatelayoutrenderer/index.md) | Class | Renders an NLog event timestamp as a Persian-calendar date with time and four fractional-second digits. The fixed output format is `yyyy-MM-dd HH:mm:ss.ffff`. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/NLog/PersianLongDateLayoutRenderer.cs#L7) |
| [PersianShortDateLayoutRenderer](kamisama-extensions-nlog-persianshortdatelayoutrenderer/index.md) | Class | Renders the date portion of an NLog event timestamp using the Persian calendar. The fixed output format is `yyyy-MM-dd`. | [source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/NLog/PersianShortDateLayoutRenderer.cs#L7) |
