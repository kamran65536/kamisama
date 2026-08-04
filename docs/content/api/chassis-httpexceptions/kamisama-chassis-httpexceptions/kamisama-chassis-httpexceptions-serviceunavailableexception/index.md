# ServiceUnavailableException

<a id="serviceunavailableexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/ServiceUnavailableException.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/ServiceUnavailableException.cs#L6)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

Thrown when some external service is not available. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class ServiceUnavailableException : HttpExceptionBase
```

## Constructors

### ServiceUnavailableException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/ServiceUnavailableException.cs#L11)

Initializes a new `ServiceUnavailableException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public ServiceUnavailableException();
```

## Parameters

This member does not declare parameters.

### ServiceUnavailableException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/ServiceUnavailableException.cs#L19)

Thrown when some external service is not available. Use it with the surrounding package APIs when composing application code.

```csharp
public ServiceUnavailableException(string serviceName) : base(nameof(ServiceUnavailableException), serviceName);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `serviceName` | `string` | `-` | Name of the service that is not available |

### ServiceUnavailableException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/ServiceUnavailableException.cs#L23)

Initializes a new `ServiceUnavailableException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public ServiceUnavailableException(string messageKey, object? [] args, Exception? innerException) : base(messageKey, args, innerException);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `messageKey` | `string` | `-` | The `messageKey` value passed to this member. |
| `args` | `object?[]` | `-` | The `args` value passed to this member. |
| `innerException` | `Exception?` | `-` | The `innerException` value passed to this member. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [StatusCode](property-statuscode-9.md) | Exposes the `StatusCode` value on `ServiceUnavailableException`. Read or set it as part of configuring or using the type. |

