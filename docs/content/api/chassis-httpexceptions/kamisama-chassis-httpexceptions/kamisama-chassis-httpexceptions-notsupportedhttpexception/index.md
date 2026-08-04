# NotSupportedHttpException

<a id="notsupportedhttpexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/NotSupportedHttpException.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/NotSupportedHttpException.cs#L6)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

he server either does not support the request method, or it lacks the ability to fulfil the request. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class NotSupportedHttpException : HttpExceptionBase
```

## Constructors

### NotSupportedHttpException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/NotSupportedHttpException.cs#L11)

Initializes a new `NotSupportedHttpException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public NotSupportedHttpException();
```

## Parameters

This member does not declare parameters.

### NotSupportedHttpException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/NotSupportedHttpException.cs#L15)

Initializes a new `NotSupportedHttpException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public NotSupportedHttpException(string messageKey, params object? [] args) : base(messageKey, args);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `messageKey` | `string` | `-` | The `messageKey` value passed to this member. |
| `args` | `object?[]` | `-` | The `args` value passed to this member. |

### NotSupportedHttpException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/NotSupportedHttpException.cs#L19)

Initializes a new `NotSupportedHttpException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public NotSupportedHttpException(string messageKey, object? [] args, Exception? innerException) : base(messageKey, args, innerException);
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
| [StatusCode](property-statuscode-9.md) | Exposes the `StatusCode` value on `NotSupportedHttpException`. Read or set it as part of configuring or using the type. |

