# ServiceUnavailableException

<a id="serviceunavailableexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/ServiceUnavailableException.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/ServiceUnavailableException.cs#L6)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

Represents a temporary service outage that should be reported with HTTP status code 503. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class ServiceUnavailableException : HttpExceptionBase
```

## Example

```csharp
using KamiSama.Chassis.HttpExceptions;

if (!catalogHealth.IsAvailable)
    throw new ServiceUnavailableException("Catalog");
```

## Constructors

### ServiceUnavailableException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/ServiceUnavailableException.cs#L11)

Initializes an exception using the exception type name as its localization key. Use it with the surrounding package APIs when composing application code.

```csharp
public ServiceUnavailableException();
```

## Parameters

This member does not declare parameters.

### ServiceUnavailableException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/ServiceUnavailableException.cs#L19)

Initializes an exception for a named unavailable service. Use it with the surrounding package APIs when composing application code.

```csharp
public ServiceUnavailableException(string serviceName) : base(nameof(ServiceUnavailableException), serviceName);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `serviceName` | `string` | `-` | Name of the service that is not available |

### ServiceUnavailableException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/ServiceUnavailableException.cs#L26)

Initializes an exception with localization metadata and an underlying exception. Use it with the surrounding package APIs when composing application code.

```csharp
public ServiceUnavailableException(string messageKey, object? [] args, Exception? innerException) : base(messageKey, args, innerException);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `messageKey` | `string` | `-` | The localization key, also used as the fallback message format. |
| `args` | `object?[]` | `-` | Values used to format and later localize the message. |
| `innerException` | `Exception?` | `-` | The exception that caused the service outage, or . |

## Members

### Properties

| Member | Description |
| --- | --- |
| [StatusCode](property-statuscode-9.md) | Gets HTTP status code 503. Use it with the surrounding package APIs when composing application code. |

