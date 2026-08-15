# BadRequestException

<a id="badrequestexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/BadRequestException.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/BadRequestException.cs#L5)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

Represents a client request that cannot be processed and should be reported with HTTP status code 400. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class BadRequestException : HttpExceptionBase
```

## Constructors

### BadRequestException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/BadRequestException.cs#L11)

Initializes an exception using the exception type name as its localization key. Use it with the surrounding package APIs when composing application code.

```csharp
public BadRequestException();
```

## Parameters

This member does not declare parameters.

### BadRequestException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/BadRequestException.cs#L17)

Initializes an exception with a localization key and formatting arguments. Use it with the surrounding package APIs when composing application code.

```csharp
public BadRequestException(string messageKey, params object? [] args) : base(messageKey, args);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `messageKey` | `string` | `-` | The localization key, also used as the fallback message format. |
| `args` | `object?[]` | `-` | Values used to format and later localize the message. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [StatusCode](property-statuscode-8.md) | Gets HTTP status code 400. Use it with the surrounding package APIs when composing application code. |

