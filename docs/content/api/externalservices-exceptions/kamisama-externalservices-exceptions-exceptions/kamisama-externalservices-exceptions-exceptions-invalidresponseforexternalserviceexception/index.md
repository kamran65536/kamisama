# InvalidResponseForExternalServiceException

<a id="invalidresponseforexternalserviceexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Exceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Exceptions/Exceptions/InvalidResponseForExternalServiceException.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Exceptions/Exceptions/InvalidResponseForExternalServiceException.cs#L11)

Namespace: `KamiSama.ExternalServices.Exceptions.Exceptions`

Kind: `Class`

## Description

Represents an invalid or unusable response returned by an external service. The service name and response details are retained as localization arguments.

## Declaration

```csharp
public class InvalidResponseForExternalServiceException(string serviceName, string details) 
    : HttpExceptionBase(nameof(InvalidResponseForExternalServiceException), serviceName, details)
```

## Example

```csharp
using KamiSama.ExternalServices.Exceptions.Exceptions;

throw new InvalidResponseForExternalServiceException("Email", "The provider response was invalid.");
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Exceptions/Exceptions/InvalidResponseForExternalServiceException.cs#L11)

Represents an invalid or unusable response returned by an external service. The service name and response details are retained as localization arguments.

```csharp
public class InvalidResponseForExternalServiceException(string serviceName, string details) 
    : HttpExceptionBase(nameof(InvalidResponseForExternalServiceException), serviceName, details)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `serviceName` | `string` | `-` | The name of the external service that returned the invalid response. |
| `details` | `string` | `-` | Details that identify or explain the invalid response. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [StatusCode](property-statuscode-17.md) | Gets the HTTP 500 Internal Server Error status code. Use it with the surrounding package APIs when composing application code. |

