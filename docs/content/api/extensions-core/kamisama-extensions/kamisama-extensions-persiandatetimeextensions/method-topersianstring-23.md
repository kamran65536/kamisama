# ToPersianString

[Back to PersianDateTimeExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/PersianDateTimeExtensions.cs:23](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/PersianDateTimeExtensions.cs#L23)

Type: `KamiSama.Extensions.PersianDateTimeExtensions`

Kind: `Method`

## Description

Formats the date and time using the Persian calendar and the default `fa-IR` date-time format. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static string ToPersianString(this DateTime dateTime);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `dateTime (extension receiver)` | `DateTime` | `-` | date time to be converted |

## Returns

| Type | Description |
| --- | --- |
| `string` | Returns a `string` value. |

## Example

```csharp
var dt = new DateTime(1, 1, 1, 13, 0, 0, persianCalendar);
```

