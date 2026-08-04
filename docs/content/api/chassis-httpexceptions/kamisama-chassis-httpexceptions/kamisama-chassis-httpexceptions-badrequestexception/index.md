# BadRequestException

<a id="badrequestexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/BadRequestException.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/BadRequestException.cs#L5)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

The server cannot or will not process the request due to an apparent client error (e.g., malformed request syntax, size too large, invalid request message framing, or deceptive request routing). Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class BadRequestException : HttpExceptionBase
```

## Constructors

### BadRequestException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/BadRequestException.cs#L11)

Initializes a new `BadRequestException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public BadRequestException();
```

## Parameters

This member does not declare parameters.

### BadRequestException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/BadRequestException.cs#L15)

Initializes a new `BadRequestException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public BadRequestException(string messageKey, params object? [] args) : base(messageKey, args);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `messageKey` | `string` | `-` | The `messageKey` value passed to this member. |
| `args` | `object?[]` | `-` | The `args` value passed to this member. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [StatusCode](property-statuscode-8.md) | Exposes the `StatusCode` value on `BadRequestException`. Read or set it as part of configuring or using the type. |

