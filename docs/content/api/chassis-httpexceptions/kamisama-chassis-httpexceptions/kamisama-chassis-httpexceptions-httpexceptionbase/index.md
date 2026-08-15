# HttpExceptionBase

<a id="httpexceptionbase"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/HttpExceptionBase.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/HttpExceptionBase.cs#L12)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

Provides the common HTTP status and localization metadata carried by KamiSama HTTP exceptions. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public abstract class HttpExceptionBase : Exception
```

## Remarks

The exception itself does not write an HTTP response. A transport adapter such as KamiSama.Chassis.ProblemDetails must convert it at the application boundary.

## Example

```csharp
using KamiSama.Chassis.HttpExceptions;

public sealed class TooManyRequestsException : HttpExceptionBase
{
    public override int StatusCode => 429;

    public TooManyRequestsException(TimeSpan retryAfter)
        : base(nameof(TooManyRequestsException), retryAfter)
    {
        ExtendedProperties["retryAfterSeconds"] = retryAfter.TotalSeconds;
    }
}
```

## Constructors

### HttpExceptionBase

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/HttpExceptionBase.cs#L32)

Initializes an exception whose localization key is the runtime exception type name. Use it with the surrounding package APIs when composing application code.

```csharp
protected HttpExceptionBase();
```

## Parameters

This member does not declare parameters.

### HttpExceptionBase

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/HttpExceptionBase.cs#L39)

Initializes an exception with a localization key and formatting arguments. Use it with the surrounding package APIs when composing application code.

```csharp
protected HttpExceptionBase(string messageKey, params object? [] args) : base(TryFormatString(messageKey, args));
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `messageKey` | `string` | `-` | The localization key, also used as the fallback message format. |
| `args` | `object?[]` | `-` | Values used to format and later localize the message. |

### HttpExceptionBase

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/HttpExceptionBase.cs#L48)

Initializes an exception with localization metadata and an underlying exception. Use it with the surrounding package APIs when composing application code.

```csharp
protected HttpExceptionBase(string messageKey, object? [] args, Exception? innerException) : base(TryFormatString(messageKey, args), innerException);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `messageKey` | `string` | `-` | The localization key, also used as the fallback message format. |
| `args` | `object?[]` | `-` | Values used to format and later localize the message. |
| `innerException` | `Exception?` | `-` | The exception that caused this failure, or . |

## Members

### Methods

| Member | Description |
| --- | --- |
| [TryFormatString](method-tryformatstring-59.md) | Formats a message without allowing an invalid composite format string to throw. Use it with the surrounding package APIs when composing application code. |

### Properties

| Member | Description |
| --- | --- |
| [ExceptionLocalizationArguments](property-exceptionlocalizationarguments-26.md) | Gets the values supplied when formatting the localized exception message. Use it with the surrounding package APIs when composing application code. |
| [ExceptionLocalizationKey](property-exceptionlocalizationkey-22.md) | Gets the resource key used to localize the exception message. Use it with the surrounding package APIs when composing application code. |
| [ExtendedProperties](property-extendedproperties-30.md) | Gets or sets additional values that an error-response adapter may expose. Use it with the surrounding package APIs when composing application code. |
| [StatusCode](property-statuscode-18.md) | Gets the HTTP status code associated with the failure. Use it with the surrounding package APIs when composing application code. |

