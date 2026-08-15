# KamiSama.Extensions.Core

[Back to package index](../index.md)

Version: `10.0.0`

## Description

Common .NET extension methods for byte and string conversion, hashing, symmetric and RSA cryptography, Persian dates, streams, arrays, queues, logging, and TimeSpan creation. Also includes lightweight paging records and an IQueryable<T> helper for producing paged results.

## How to use

```shell
dotnet add package KamiSama.Extensions.Core --version 10.0.0
```

## Namespaces

- [KamiSama.Extensions](kamisama-extensions/index.md) (12 types)
- [KamiSama.Extensions.Paging](kamisama-extensions-paging/index.md) (2 types)

## Types

- [KamiSama.Extensions.ArrayExtensions](kamisama-extensions/kamisama-extensions-arrayextensions/index.md) - Provides extension methods for padding arrays and removing matching trailing elements. Use these helpers when an array must be resized or normalized without mutating the original instance.
- [KamiSama.Extensions.ByteArrayExtensions](kamisama-extensions/kamisama-extensions-bytearrayextensions/index.md) - Provides extension methods for converting byte arrays to text, hexadecimal strings, and Base64 strings. Use them to prepare binary data for display, storage, or transport.
- [KamiSama.Extensions.ConversionExtensions](kamisama-extensions/kamisama-extensions-conversionextensions/index.md) - Provides fallback-based conversion of objects to runtime or generic target types. Failed conversions return the caller-provided default value instead of throwing.
- [KamiSama.Extensions.CryptographyExtensions](kamisama-extensions/kamisama-extensions-cryptographyextensions/index.md) - Provides byte-array encryption, decryption, and CBC-based authentication helpers for symmetric algorithms, plus RSA encryption and decryption. Legacy algorithms are included for interoperability; prefer modern authenticated encryption for new designs.
- [KamiSama.Extensions.HashExtensions](kamisama-extensions/kamisama-extensions-hashextensions/index.md) - Provides hash-computation helpers for byte arrays and strings, including hexadecimal MD5 and SHA-1 output. Prefer a modern hash algorithm for new security-sensitive applications.
- [KamiSama.Extensions.IQueryableExtensions](kamisama-extensions/kamisama-extensions-iqueryableextensions/index.md) - Provides extensions for materializing `IQueryable{T}` sequences as paged results. Use them after applying filtering and ordering to a query.
- [KamiSama.Extensions.LoggerExtensions](kamisama-extensions/kamisama-extensions-loggerextensions/index.md) - Provides diagnostic logging extensions for `ILogger`. Use them to emit consistent trace-level method-entry messages.
- [KamiSama.Extensions.PersianDateTimeExtensions](kamisama-extensions/kamisama-extensions-persiandatetimeextensions/index.md) - Provides formatting and parsing extensions that use the Persian calendar and the `fa-IR` date-time format. Use them when Persian-calendar text must be exchanged with `DateTime` values.
- [KamiSama.Extensions.QueueExtensions](kamisama-extensions/kamisama-extensions-queueextensions/index.md) - Provides extensions for safely dequeuing a value or returning a fallback when a queue is empty. Use them when an empty queue is an expected condition rather than an error.
- [KamiSama.Extensions.StreamExtensions](kamisama-extensions/kamisama-extensions-streamextensions/index.md) - Provides synchronous and asynchronous helpers for reading an exact number of bytes from a stream. The helpers fail when the requested byte count cannot be obtained.
- [KamiSama.Extensions.StringExtensions](kamisama-extensions/kamisama-extensions-stringextensions/index.md) - Provides extensions for encoding strings and decoding hexadecimal and Base64 text. Use them to move between textual representations and byte arrays.
- [KamiSama.Extensions.TimeSpanExtensions](kamisama-extensions/kamisama-extensions-timespanextensions/index.md) - Provides fluent numeric extensions for constructing `TimeSpan` values in common units. Both integer and fractional values are supported.
- [KamiSama.Extensions.Paging.PagedResult<T>](kamisama-extensions-paging/kamisama-extensions-paging-pagedresult-t/index.md) - Represents one materialized page of items together with the total number of matching items. Use it to return page data without losing the count needed by callers to render pagination.
- [KamiSama.Extensions.Paging.SearchModel](kamisama-extensions-paging/kamisama-extensions-paging-searchmodel/index.md) - Represents paging and optional ordering criteria for a query. A page size of zero requests all matching items.
