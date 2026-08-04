# TryParseExactAsPersianDateTime

[Back to PersianDateTimeExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/PersianDateTimeExtensions.cs:62](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/PersianDateTimeExtensions.cs#L62)

Type: `KamiSama.Extensions.PersianDateTimeExtensions`

Kind: `Method`

## Description

Parses a string as persian date time as exact format (using PersianCalendar default date time format info). Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static bool TryParseExactAsPersianDateTime(this string str, string format, out DateTime dateTime);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `str (extension receiver)` | `string` | `-` | string to be parsed as datetime |
| `format` | `string` | `-` | formatting to be matched |
| `dateTime (out)` | `DateTime` | `-` | result date time |

## Returns

| Type | Description |
| --- | --- |
| `bool` | true if parsing is successful |

## Example

```csharp
var str = "001/01/01 01:02:03";
var result = str.TryParseExactAsPersianDateTime("yyyy/MM/dd HH:mm:ss", out _);
```

