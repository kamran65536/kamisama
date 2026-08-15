# PersianDateTimeExtensions

<a id="persiandatetimeextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Core/PersianDateTimeExtensions.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/PersianDateTimeExtensions.cs#L7)

Namespace: `KamiSama.Extensions`

Kind: `Class`

## Description

Provides formatting and parsing extensions that use the Persian calendar and the `fa-IR` date-time format. Use them when Persian-calendar text must be exchanged with `DateTime` values.

## Declaration

```csharp
public static class PersianDateTimeExtensions
```

## Example

```csharp
DateTime date = new(2026, 3, 21);
string persianDate = date.ToPersianString("yyyy/MM/dd");
DateTime parsed = persianDate.ParseExactAsPersianDateTime("yyyy/MM/dd");
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ParseAsPersianDateTime](method-parseaspersiandatetime-38.md) | Parses the string as a date and time using the Persian calendar&apos;s default format information. Use it with the surrounding package APIs when composing application code. |
| [ParseExactAsPersianDateTime](method-parseexactaspersiandatetime-46.md) | Parses the string as a Persian-calendar date and time that must match the specified format exactly. Use it with the surrounding package APIs when composing application code. |
| [ToPersianString](method-topersianstring-23.md) | Formats the date and time using the Persian calendar and the default `fa-IR` date-time format. Use it with the surrounding package APIs when composing application code. |
| [ToPersianString](method-topersianstring-31.md) | Formats the date and time with the specified format string using the Persian calendar. Use it with the surrounding package APIs when composing application code. |
| [TryParseAsPersianDateTime](method-tryparseaspersiandatetime-54.md) | Attempts to parse the string as a date and time using the Persian calendar&apos;s default format information. Use it with the surrounding package APIs when composing application code. |
| [TryParseExactAsPersianDateTime](method-tryparseexactaspersiandatetime-63.md) | Attempts to parse the string as a Persian-calendar date and time that exactly matches the specified format. Use it with the surrounding package APIs when composing application code. |

