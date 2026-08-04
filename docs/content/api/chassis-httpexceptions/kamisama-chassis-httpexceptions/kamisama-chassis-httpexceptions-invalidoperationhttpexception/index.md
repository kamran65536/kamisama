# InvalidOperationHttpException

<a id="invalidoperationhttpexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/InvalidOperationHttpException.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/InvalidOperationHttpException.cs#L6)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

Equivalant to `InvalidOperationException` but in the http mode. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class InvalidOperationHttpException : HttpExceptionBase
```

## Constructors

### InvalidOperationHttpException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/InvalidOperationHttpException.cs#L11)

Initializes a new `InvalidOperationHttpException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public InvalidOperationHttpException();
```

## Parameters

This member does not declare parameters.

### InvalidOperationHttpException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/InvalidOperationHttpException.cs#L15)

Initializes a new `InvalidOperationHttpException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public InvalidOperationHttpException(string message, params object? [] args) : base(message, args);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `message` | `string` | `-` | The `message` value passed to this member. |
| `args` | `object?[]` | `-` | The `args` value passed to this member. |

### InvalidOperationHttpException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/InvalidOperationHttpException.cs#L19)

Initializes a new `InvalidOperationHttpException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public InvalidOperationHttpException(string messageKey, object? [] args, Exception? innerException) : base(messageKey, args, innerException);
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
| [StatusCode](property-statuscode-9.md) | Exposes the `StatusCode` value on `InvalidOperationHttpException`. Read or set it as part of configuring or using the type. |

