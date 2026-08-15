---
last-checked-utc: 2026-08-14T19:32:45Z
root-version: 10.0.0
classes-without-examples: []
---

# Documentation Snapshot

The package description, public API summaries, usage guidance, and class-level example coverage were reviewed against the source at the recorded root version.

## Description

Iran System encoding conversion helpers for legacy Persian text interoperability. Use this package when integrating with systems that still exchange Iran System encoded data.

## How to use

```shell
dotnet add package KamiSama.IranSystem --version 10.0.0
```

Use `IranSystemEncoding` to decode complete Iran System byte arrays or encode strings containing the exact mapped presentation-form characters. Iran System is glyph based, so decoded Persian text is not normalized Unicode text; unsupported input characters encode as `0xFF`, which decodes as a non-breaking space.

## Example decisions

`IranSystemEncoding` has a class-level example because it is the package's encoding implementation and primary entry point.
