# CannotFindExternalServiceException

<a id="cannotfindexternalserviceexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Exceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Exceptions/Exceptions/CannotFindExternalServiceException.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Exceptions/Exceptions/CannotFindExternalServiceException.cs#L11)

Namespace: `KamiSama.ExternalServices.Exceptions.Exceptions`

Kind: `Class`

## Description

Represents a server error caused by the absence of a configured external service implementation. The service name and configuration value are retained as localization arguments.

## Declaration

```csharp
public class CannotFindExternalServiceException(string serviceName, string serviceConfiguration) : HttpExceptionBase(nameof(CannotFindExternalServiceException), serviceName, serviceConfiguration)
```

## Example

```csharp
using KamiSama.ExternalServices.Exceptions.Exceptions;

throw new CannotFindExternalServiceException("Email", configuredProvider);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Exceptions/Exceptions/CannotFindExternalServiceException.cs#L11)

Represents a server error caused by the absence of a configured external service implementation. The service name and configuration value are retained as localization arguments.

```csharp
public class CannotFindExternalServiceException(string serviceName, string serviceConfiguration) : HttpExceptionBase(nameof(CannotFindExternalServiceException), serviceName, serviceConfiguration)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `serviceName` | `string` | `-` | The external service contract or integration name. |
| `serviceConfiguration` | `string` | `-` | The configured provider or service value that could not be resolved. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [StatusCode](property-statuscode-16.md) | Gets the HTTP 500 Internal Server Error status code. Use it with the surrounding package APIs when composing application code. |

