# LogMethodEntry

[Back to LoggerExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/LoggerExtensions.cs:19](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/LoggerExtensions.cs#L19)

Type: `KamiSama.Extensions.LoggerExtensions`

Kind: `Method`

## Description

Logs a trace-level method-entry message containing the caller name and any supplied argument values. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static void LogMethodEntry(this ILogger logger, [CallerMemberName] string caller = "", params object[] argsToLog);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `logger (extension receiver)` | `ILogger` | `-` | The `logger` value passed to this member. |
| `caller` | `string` | `""` | The `caller` value passed to this member. |
| `argsToLog` | `object[]` | `-` | The `argsToLog` value passed to this member. |

## Example

No concise standalone example is available yet.

