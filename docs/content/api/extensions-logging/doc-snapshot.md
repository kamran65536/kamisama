---
last-checked-utc: 2026-08-14T19:38:18Z
root-version: 10.0.0
classes-without-examples: []
---

# Documentation Snapshot

The package description, public API summaries, usage guidance, and class-level example coverage were reviewed against the source at the recorded root version.

## Description

Trace method entry through Microsoft.Extensions.Logging without repeating caller names. LogMethodEntry emits a Trace event containing the inferred calling type and member name and can include selected argument values for diagnostics.

## How to use

```shell
dotnet add package KamiSama.Extensions.Logging --version 10.0.0
```

Import the extension and inject an `ILogger<T>` into the service that emits method-entry events:

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

Enable the `Trace` level for the relevant environment and category, for example with `Logging:LogLevel:Default` set to `Trace`. `LogMethodEntry` creates a stack trace on every call, even when Trace logging is disabled, and async callers can report a compiler-generated state-machine type. Multiple supplied arguments currently pass through one `Args` placeholder and may render as an array instead of individually named values. Select logged arguments deliberately and never include secrets, credentials, tokens, personal data, or other sensitive information.

## Example decisions

Every public class has a class-level example.
