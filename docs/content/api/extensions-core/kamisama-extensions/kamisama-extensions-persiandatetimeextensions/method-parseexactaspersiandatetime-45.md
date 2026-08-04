# ParseExactAsPersianDateTime

[Back to PersianDateTimeExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/PersianDateTimeExtensions.cs:45](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/PersianDateTimeExtensions.cs#L45)

Type: `KamiSama.Extensions.PersianDateTimeExtensions`

Kind: `Method`

## Description

Parses a string as persian date time as exact format (using PersianCalendar default date time format info). Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static DateTime ParseExactAsPersianDateTime(this string str, string format);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `str (extension receiver)` | `string` | `-` | string to be parsed as datetime |
| `format` | `string` | `-` | formatting to be matched |

## Returns

| Type | Description |
| --- | --- |
| `DateTime` | Returns a `DateTime` value. |

## Example

```csharp
var str = "0001/01/01 01:02:03";
var expected = new DateTime(1, 1, 1, 1, 2, 3, persianCalendar);

var parsed = str.ParseExactAsPersianDateTime("yyyy/MM/dd HH:mm:ss");
```

