# InvalidResponseForExternalServiceException

<a id="invalidresponseforexternalserviceexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Exceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Exceptions/Exceptions/InvalidResponseForExternalServiceException.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Exceptions/Exceptions/InvalidResponseForExternalServiceException.cs#L5)

Namespace: `KamiSama.ExternalServices.Exceptions.Exceptions`

Kind: `Class`

## Description

Provides the `InvalidResponseForExternalServiceException` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public class InvalidResponseForExternalServiceException(string serviceName, string details) 
    : HttpExceptionBase(nameof(InvalidResponseForExternalServiceException), serviceName, details)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Exceptions/Exceptions/InvalidResponseForExternalServiceException.cs#L5)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public class InvalidResponseForExternalServiceException(string serviceName, string details) 
    : HttpExceptionBase(nameof(InvalidResponseForExternalServiceException), serviceName, details)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `serviceName` | `string` | `-` | The `serviceName` value passed to this member. |
| `details` | `string` | `-` | The `details` value passed to this member. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [StatusCode](property-statuscode-8.md) | Exposes the `StatusCode` value on `InvalidResponseForExternalServiceException`. Read or set it as part of configuring or using the type. |

