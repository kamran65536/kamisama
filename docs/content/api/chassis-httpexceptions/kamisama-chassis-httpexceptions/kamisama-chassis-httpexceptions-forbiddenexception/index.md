# ForbiddenException

<a id="forbiddenexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/ForbiddenException.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/ForbiddenException.cs#L5)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

Represents an understood request that the server refuses to perform and should be reported with HTTP status code 403. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class ForbiddenException : HttpExceptionBase
```

## Constructors

### ForbiddenException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/ForbiddenException.cs#L10)

Initializes an exception using the exception type name as its localization key. Use it with the surrounding package APIs when composing application code.

```csharp
public ForbiddenException();
```

## Parameters

This member does not declare parameters.

### ForbiddenException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/ForbiddenException.cs#L16)

Initializes an exception with a localization key and formatting arguments. Use it with the surrounding package APIs when composing application code.

```csharp
public ForbiddenException(string messageKey, params object? [] args) : base(messageKey, args);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `messageKey` | `string` | `-` | The localization key, also used as the fallback message format. |
| `args` | `object?[]` | `-` | Values used to format and later localize the message. |

### ForbiddenException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/ForbiddenException.cs#L23)

Initializes an exception with localization metadata and an underlying exception. Use it with the surrounding package APIs when composing application code.

```csharp
public ForbiddenException(string messageKey, object? [] args, Exception? innerException) : base(messageKey, args, innerException);
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
| [StatusCode](property-statuscode-8.md) | Gets HTTP status code 403. Use it with the surrounding package APIs when composing application code. |

