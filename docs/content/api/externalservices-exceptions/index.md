# KamiSama.ExternalServices.Exceptions

[Back to package index](../index.md)

Version: `10.0.0`

## Description

HTTP-oriented exceptions for external-service discovery failures, timeouts, and invalid provider responses. Use them at integration boundaries to expose consistent localization keys, arguments, and 500 or 504 status codes.

## How to use

```shell
dotnet add package KamiSama.ExternalServices.Exceptions --version 10.0.0
```

Throw these exceptions at an external-service boundary so KamiSama problem-details handling can expose a consistent localization key, arguments, and status code:

```csharp
using KamiSama.ExternalServices.Exceptions.Exceptions;

if (provider is null)
    throw new CannotFindExternalServiceException("Email", configuredProvider);

if (response.TimedOut)
    throw new ExternalServiceTimedOutException("Email", "The provider did not respond in time.");

if (!response.IsValid)
    throw new InvalidResponseForExternalServiceException("Email", "The provider response was invalid.");
```

## Namespaces

- [KamiSama.ExternalServices.Exceptions.Exceptions](kamisama-externalservices-exceptions-exceptions/index.md) (3 types)

## Types

- [KamiSama.ExternalServices.Exceptions.Exceptions.CannotFindExternalServiceException](kamisama-externalservices-exceptions-exceptions/kamisama-externalservices-exceptions-exceptions-cannotfindexternalserviceexception/index.md) - Represents a server error caused by the absence of a configured external service implementation. The service name and configuration value are retained as localization arguments.
- [KamiSama.ExternalServices.Exceptions.Exceptions.ExternalServiceTimedOutException](kamisama-externalservices-exceptions-exceptions/kamisama-externalservices-exceptions-exceptions-externalservicetimedoutexception/index.md) - Represents an external service operation that did not complete before its timeout. The service name and timeout details are retained as localization arguments.
- [KamiSama.ExternalServices.Exceptions.Exceptions.InvalidResponseForExternalServiceException](kamisama-externalservices-exceptions-exceptions/kamisama-externalservices-exceptions-exceptions-invalidresponseforexternalserviceexception/index.md) - Represents an invalid or unusable response returned by an external service. The service name and response details are retained as localization arguments.
