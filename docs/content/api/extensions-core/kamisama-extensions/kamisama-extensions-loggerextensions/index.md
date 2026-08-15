# LoggerExtensions

<a id="loggerextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Core/LoggerExtensions.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/LoggerExtensions.cs#L11)

Namespace: `KamiSama.Extensions`

Kind: `Class`

## Description

Provides diagnostic logging extensions for `ILogger`. Use them to emit consistent trace-level method-entry messages.

## Declaration

```csharp
public static class LoggerExtensions
```

## Example

```csharp
using Microsoft.Extensions.Logging;

void ProcessOrder(ILogger logger, Guid orderId)
{
    logger.LogMethodEntry(argsToLog: orderId);
}
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [LogMethodEntry](method-logmethodentry-19.md) | Logs a trace-level method-entry message containing the caller name and any supplied argument values. Use it with the surrounding package APIs when composing application code. |

