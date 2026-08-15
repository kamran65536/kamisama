# KamiSama.Extensions.Logging

[Back to package index](../index.md)

Version: `10.0.0`

## Description

Trace method entry through Microsoft.Extensions.Logging without repeating caller names. LogMethodEntry emits a Trace event containing the inferred calling type and member name and can include selected argument values for diagnostics.

## How to use

```shell
dotnet add package KamiSama.Extensions.Logging --version 10.0.0
```

Import the logging extension and inject an `ILogger<T>` into the service that emits method-entry events:

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

Enable the `Trace` level for the relevant environment and category, for example with `Logging:LogLevel:Default` set to `Trace`. Argument values are written to logs, so select them deliberately and never include secrets, credentials, tokens, personal data, or other sensitive information.

## Namespaces

- [KamiSama.Extensions.Logging](kamisama-extensions-logging/index.md) (1 types)

## Types

- [KamiSama.Extensions.Logging.LoggerExtensions](kamisama-extensions-logging/kamisama-extensions-logging-loggerextensions/index.md) - Extends `ILogger` with method-entry tracing that infers the calling member and declaring type. Use it to add consistent diagnostic entry events without repeating caller names in log statements.
