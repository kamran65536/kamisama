# LoggerExtensions

<a id="loggerextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Logging](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Extensions.Logging/LoggerExtensions.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.Logging/LoggerExtensions.cs#L15)

Namespace: `KamiSama.Extensions.Logging`

Kind: `Class`

## Description

Extends `ILogger` with method-entry tracing that infers the calling member and declaring type. Use it to add consistent diagnostic entry events without repeating caller names in log statements.

## Declaration

```csharp
public static class LoggerExtensions
```

## Remarks

Caller inference creates a `StackTrace` on every call, even when Trace logging is disabled. The inferred declaring type can be a compiler-generated state-machine type when called from an async method.

## Example

```csharp
using KamiSama.Extensions.Logging;
using Microsoft.Extensions.Logging;

public sealed class OrderService(ILogger<OrderService> logger)
{
    public void Process(Guid orderId)
    {
        logger.LogMethodEntry(argsToLog: orderId);
    }
}
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [LogMethodEntry](method-logmethodentry-36.md) | Writes a Trace event for the inferred calling type and member name. Optionally includes selected argument values in the diagnostic event. |

