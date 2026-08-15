# UnAuthorizedException

<a id="unauthorizedexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/UnAuthorizedException.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/UnAuthorizedException.cs#L8)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

Represents an unauthenticated request that should be reported with HTTP status code 401. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class UnAuthorizedException : HttpExceptionBase
```

## Constructors

### UnAuthorizedException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/UnAuthorizedException.cs#L14)

Initializes an exception using the exception type name as its localization key. Use it with the surrounding package APIs when composing application code.

```csharp
public UnAuthorizedException();
```

## Parameters

This member does not declare parameters.

### UnAuthorizedException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/UnAuthorizedException.cs#L20)

Initializes an exception with a localization key and formatting arguments. Use it with the surrounding package APIs when composing application code.

```csharp
public UnAuthorizedException(string messageKey, params object? [] args) : base(messageKey, args);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `messageKey` | `string` | `-` | The localization key, also used as the fallback message format. |
| `args` | `object?[]` | `-` | Values used to format and later localize the message. |

### UnAuthorizedException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/UnAuthorizedException.cs#L27)

Initializes an exception with localization metadata and an underlying exception. Use it with the surrounding package APIs when composing application code.

```csharp
public UnAuthorizedException(string messageKey, object? [] args, Exception? innerException) : base(messageKey, args, innerException);
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
| [StatusCode](property-statuscode-12.md) | Gets HTTP status code 401. Use it with the surrounding package APIs when composing application code. |

