# NotImplementedHttpException

<a id="notimplementedhttpexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/NotImplementedException.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/NotImplementedException.cs#L7)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

he server either does not recognize the request method, or it lacks the ability to fulfil the request. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class NotImplementedHttpException : HttpExceptionBase
```

## Constructors

### NotImplementedHttpException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/NotImplementedException.cs#L13)

Initializes a new `NotImplementedHttpException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public NotImplementedHttpException();
```

## Parameters

This member does not declare parameters.

### NotImplementedHttpException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/NotImplementedException.cs#L17)

Initializes a new `NotImplementedHttpException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public NotImplementedHttpException(string message, params object? [] args) : base(message, args);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `message` | `string` | `-` | The `message` value passed to this member. |
| `args` | `object?[]` | `-` | The `args` value passed to this member. |

### NotImplementedHttpException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/NotImplementedException.cs#L21)

Initializes a new `NotImplementedHttpException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public NotImplementedHttpException(string messageKey, object? [] args, Exception? innerException) : base(messageKey, args, innerException);
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
| [StatusCode](property-statuscode-11.md) | Exposes the `StatusCode` value on `NotImplementedHttpException`. Read or set it as part of configuring or using the type. |

