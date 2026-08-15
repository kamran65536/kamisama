# KamiSama.IranSystem

[Back to package index](../index.md)

Version: `10.0.0`

## Description

Iran System encoding conversion helpers for legacy Persian text interoperability. Use this package when integrating with systems that still exchange Iran System encoded data.

## How to use

```shell
dotnet add package KamiSama.IranSystem --version 10.0.0
```

Create an `IranSystemEncoding` instance and use its string-based methods for complete buffers:

```csharp
using KamiSama.IranSystem;

var encoding = new IranSystemEncoding();
string text = encoding.GetString(iranSystemBytes);
byte[] bytes = encoding.GetBytes(text);
```

Iran System stores contextual glyph shapes, so decoded Persian text contains Arabic presentation-form characters rather than normalized letters. Encoding requires those exact mapped code points; unsupported characters are written as `0xFF`, which decodes as a non-breaking space.

## Namespaces

- [KamiSama.IranSystem](kamisama-iransystem/index.md) (1 types)

## Types

- [KamiSama.IranSystem.IranSystemEncoding](kamisama-iransystem/kamisama-iransystem-iransystemencoding/index.md) - A `System.Text.Encoding` implementation for converting between legacy single-byte Iran System data and Unicode characters. Use its complete-buffer string methods when exchanging data with legacy Persian systems.
