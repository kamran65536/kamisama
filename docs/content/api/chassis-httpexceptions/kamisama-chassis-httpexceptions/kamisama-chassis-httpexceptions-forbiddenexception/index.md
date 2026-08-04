# ForbiddenException

<a id="forbiddenexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/ForbiddenException.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/ForbiddenException.cs#L5)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

The request contained valid data and was understood by the server, but the server is refusing action. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class ForbiddenException : HttpExceptionBase
```

## Constructors

### ForbiddenException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/ForbiddenException.cs#L10)

Initializes a new `ForbiddenException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public ForbiddenException();
```

## Parameters

This member does not declare parameters.

### ForbiddenException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/ForbiddenException.cs#L14)

Initializes a new `ForbiddenException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public ForbiddenException(string messageKey, params object? [] args) : base(messageKey, args);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `messageKey` | `string` | `-` | The `messageKey` value passed to this member. |
| `args` | `object?[]` | `-` | The `args` value passed to this member. |

### ForbiddenException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/ForbiddenException.cs#L18)

Initializes a new `ForbiddenException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public ForbiddenException(string messageKey, object? [] args, Exception? innerException) : base(messageKey, args, innerException);
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
| [StatusCode](property-statuscode-8.md) | Exposes the `StatusCode` value on `ForbiddenException`. Read or set it as part of configuring or using the type. |

