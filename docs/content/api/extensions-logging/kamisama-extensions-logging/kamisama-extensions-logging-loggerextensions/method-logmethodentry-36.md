# LogMethodEntry

[Back to LoggerExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Logging](../../index.md)

Source: [src/KamiSama.Extensions.Logging/LoggerExtensions.cs:36](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.Logging/LoggerExtensions.cs#L36)

Type: `KamiSama.Extensions.Logging.LoggerExtensions`

Kind: `Method`

## Description

Writes a Trace event for the inferred calling type and member name. Optionally includes selected argument values in the diagnostic event.

## Declaration

```csharp
public static void LogMethodEntry(this ILogger logger, [CallerMemberName] string caller = "", params object[] argsToLog);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `logger (extension receiver)` | `ILogger` | `-` | The logger that receives the Trace event. |
| `caller` | `string` | `""` | The calling member name supplied automatically by the compiler. Pass a value explicitly only to override the inferred member name. |
| `argsToLog` | `object[]` | `-` | The selected argument values to attach to the entry event. Avoid secrets, credentials, tokens, personal data, and other sensitive values. |

## Remarks

This method creates a stack trace before logging, so it adds stack-walking overhead even when Trace logging is disabled. Calls from async methods can report a compiler-generated state-machine type instead of the original declaring type. The current message template passes all supplied argument values through one `Args` placeholder; multiple values may therefore be rendered as an array rather than as individually named values.

## Example

No concise standalone example is available yet.

