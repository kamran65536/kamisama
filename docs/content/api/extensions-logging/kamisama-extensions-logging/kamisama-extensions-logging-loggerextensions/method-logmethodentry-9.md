# LogMethodEntry

[Back to LoggerExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Logging](../../index.md)

Source: [src/KamiSama.Extensions.Logging/LoggerExtensions.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.Logging/LoggerExtensions.cs#L9)

Type: `KamiSama.Extensions.Logging.LoggerExtensions`

Kind: `Method`

## Description

Runs the `LogMethodEntry` operation on `LoggerExtensions`. Use it when your code needs this specific behavior from the package.

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

