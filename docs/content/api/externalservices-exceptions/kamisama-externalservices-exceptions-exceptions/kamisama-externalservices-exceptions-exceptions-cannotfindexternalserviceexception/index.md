# CannotFindExternalServiceException

<a id="cannotfindexternalserviceexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Exceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Exceptions/Exceptions/CannotFindExternalServiceException.cs:4](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Exceptions/Exceptions/CannotFindExternalServiceException.cs#L4)

Namespace: `KamiSama.ExternalServices.Exceptions.Exceptions`

Kind: `Class`

## Description

Provides the `CannotFindExternalServiceException` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public class CannotFindExternalServiceException(string serviceName, string serviceConfiguration) : HttpExceptionBase(nameof(CannotFindExternalServiceException), serviceName, serviceConfiguration)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Exceptions/Exceptions/CannotFindExternalServiceException.cs#L4)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public class CannotFindExternalServiceException(string serviceName, string serviceConfiguration) : HttpExceptionBase(nameof(CannotFindExternalServiceException), serviceName, serviceConfiguration)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `serviceName` | `string` | `-` | The `serviceName` value passed to this member. |
| `serviceConfiguration` | `string` | `-` | The `serviceConfiguration` value passed to this member. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [StatusCode](property-statuscode-6.md) | Exposes the `StatusCode` value on `CannotFindExternalServiceException`. Read or set it as part of configuring or using the type. |

