# TryParseAsPersianDateTime

[Back to PersianDateTimeExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/PersianDateTimeExtensions.cs:53](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/PersianDateTimeExtensions.cs#L53)

Type: `KamiSama.Extensions.PersianDateTimeExtensions`

Kind: `Method`

## Description

Parses a string as persian date time (using PersianCalendar default date time format info). Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static bool TryParseAsPersianDateTime(this string str, out DateTime dateTime);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `str (extension receiver)` | `string` | `-` | string to be parsed as datetime |
| `dateTime (out)` | `DateTime` | `-` | result date time |

## Returns

| Type | Description |
| --- | --- |
| `bool` | true if parsing is successful |

## Example

```csharp
var str = "abc";
var result = str.TryParseAsPersianDateTime(out _);
```

