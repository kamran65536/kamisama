# TryFormatString

[Back to HttpExceptionBase](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md)

Source: [src/Chassis.Exceptions/HttpExceptionBase.cs:59](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/HttpExceptionBase.cs#L59)

Type: `KamiSama.Chassis.HttpExceptions.HttpExceptionBase`

Kind: `Method`

## Description

Formats a message without allowing an invalid composite format string to throw. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static string TryFormatString(string message, params object? [] args);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `message` | `string` | `-` | The composite format string or fallback text. |
| `args` | `object?[]` | `-` | Values to insert into the format string. |

## Returns

| Type | Description |
| --- | --- |
| `string` | The formatted message, or the original message when formatting fails. |

## Example

No concise standalone example is available yet.

