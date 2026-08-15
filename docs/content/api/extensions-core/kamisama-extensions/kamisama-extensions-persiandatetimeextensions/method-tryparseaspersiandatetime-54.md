# TryParseAsPersianDateTime

[Back to PersianDateTimeExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/PersianDateTimeExtensions.cs:54](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/PersianDateTimeExtensions.cs#L54)

Type: `KamiSama.Extensions.PersianDateTimeExtensions`

Kind: `Method`

## Description

Attempts to parse the string as a date and time using the Persian calendar&apos;s default format information. Use it with the surrounding package APIs when composing application code.

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

