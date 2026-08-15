# UnProcessableEntityException

<a id="unprocessableentityexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/UnProcessableEntityException.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/UnProcessableEntityException.cs#L6)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

Represents a semantically invalid request that should be reported with HTTP status code 422. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class UnProcessableEntityException : HttpExceptionBase
```

## Constructors

### UnProcessableEntityException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/UnProcessableEntityException.cs#L11)

Initializes an exception using the exception type name as its localization key. Use it with the surrounding package APIs when composing application code.

```csharp
public UnProcessableEntityException();
```

## Parameters

This member does not declare parameters.

### UnProcessableEntityException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/UnProcessableEntityException.cs#L17)

Initializes an exception with a localization key and formatting arguments. Use it with the surrounding package APIs when composing application code.

```csharp
public UnProcessableEntityException(string messageKey, params object? [] args) : base(messageKey, args);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `messageKey` | `string` | `-` | The localization key, also used as the fallback message format. |
| `args` | `object?[]` | `-` | Values used to format and later localize the message. |

### UnProcessableEntityException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/UnProcessableEntityException.cs#L24)

Initializes an exception with localization metadata and an underlying exception. Use it with the surrounding package APIs when composing application code.

```csharp
public UnProcessableEntityException(string messageKey, object? [] args, Exception? innerException) : base(messageKey, args, innerException);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `messageKey` | `string` | `-` | The localization key, also used as the fallback message format. |
| `args` | `object?[]` | `-` | Values used to format and later localize the message. |
| `innerException` | `Exception?` | `-` | The exception that caused this failure, or . |

## Members

### Properties

| Member | Description |
| --- | --- |
| [StatusCode](property-statuscode-9.md) | Gets HTTP status code 422. Use it with the surrounding package APIs when composing application code. |

