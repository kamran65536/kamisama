# ExternalServiceTimedOutException

<a id="externalservicetimedoutexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Exceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Exceptions/Exceptions/ExternalServiceTimedOutException.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Exceptions/Exceptions/ExternalServiceTimedOutException.cs#L11)

Namespace: `KamiSama.ExternalServices.Exceptions.Exceptions`

Kind: `Class`

## Description

Represents an external service operation that did not complete before its timeout. The service name and timeout details are retained as localization arguments.

## Declaration

```csharp
public class ExternalServiceTimedOutException(string serviceName, string details) :
    HttpExceptionBase(nameof(ExternalServiceTimedOutException), serviceName, details)
```

## Example

```csharp
using KamiSama.ExternalServices.Exceptions.Exceptions;

throw new ExternalServiceTimedOutException("Email", "The provider did not respond in time.");
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Exceptions/Exceptions/ExternalServiceTimedOutException.cs#L11)

Represents an external service operation that did not complete before its timeout. The service name and timeout details are retained as localization arguments.

```csharp
public class ExternalServiceTimedOutException(string serviceName, string details) :
    HttpExceptionBase(nameof(ExternalServiceTimedOutException), serviceName, details)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `serviceName` | `string` | `-` | The name of the external service that timed out. |
| `details` | `string` | `-` | Details that identify or explain the timeout. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [StatusCode](property-statuscode-17.md) | Gets the HTTP 504 Gateway Timeout status code. Use it with the surrounding package APIs when composing application code. |

