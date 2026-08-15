# NotImplementedHttpException

<a id="notimplementedhttpexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/NotImplementedException.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/NotImplementedException.cs#L7)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

Represents server functionality that is not implemented and should be reported with HTTP status code 501. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class NotImplementedHttpException : HttpExceptionBase
```

## Constructors

### NotImplementedHttpException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/NotImplementedException.cs#L13)

Initializes an exception using the exception type name as its localization key. Use it with the surrounding package APIs when composing application code.

```csharp
public NotImplementedHttpException();
```

## Parameters

This member does not declare parameters.

### NotImplementedHttpException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/NotImplementedException.cs#L19)

Initializes an exception with a localization key and formatting arguments. Use it with the surrounding package APIs when composing application code.

```csharp
public NotImplementedHttpException(string message, params object? [] args) : base(message, args);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `message` | `string` | `-` | The localization key, also used as the fallback message format. |
| `args` | `object?[]` | `-` | Values used to format and later localize the message. |

### NotImplementedHttpException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/NotImplementedException.cs#L26)

Initializes an exception with localization metadata and an underlying exception. Use it with the surrounding package APIs when composing application code.

```csharp
public NotImplementedHttpException(string messageKey, object? [] args, Exception? innerException) : base(messageKey, args, innerException);
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
| [StatusCode](property-statuscode-11.md) | Gets HTTP status code 501. Use it with the surrounding package APIs when composing application code. |

