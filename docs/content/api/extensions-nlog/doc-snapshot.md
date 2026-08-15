---
last-checked-utc: 2026-08-14T19:41:40Z
root-version: 10.0.0
classes-without-examples: []
---

# Documentation Snapshot

The package description, public and protected API summaries, usage guidance, and class-level example coverage were reviewed against the source at the recorded root version.

## Description

NLog extensions for rendering Persian-calendar timestamps and archiving log files in password-protected ZIP files using SharpZipLib.

## How to use

```shell
dotnet add package KamiSama.Extensions.NLog --version 10.0.0
```

Register `KamiSama.Extensions.NLog` as an NLog extension assembly, then use `${persian-date}`, `${persian-longDate}`, or `${persian-shortDate}` in layouts. Set `ConcurrentFileTarget.FileCompressor` to an `EncryptedZipArchiveFileCompressor` to create password-protected ZIP archives. Supply its `PasswordFunc` from secure configuration and never hardcode archive passwords in source code or `NLog.config`.

## Example decisions

Every public class has a class-level example. The `PasswordFunc` delegate is demonstrated by the compressor example and does not need a separate class-level example.
