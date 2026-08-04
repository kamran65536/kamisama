# PaymentRequiredException

<a id="paymentrequiredexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/PaymentRequiredException.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/PaymentRequiredException.cs#L6)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

The original intention was that this code might be used as part of some form of digital cash or micropayment scheme. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class PaymentRequiredException : HttpExceptionBase
```

## Constructors

### PaymentRequiredException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/PaymentRequiredException.cs#L11)

Initializes a new `PaymentRequiredException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public PaymentRequiredException();
```

## Parameters

This member does not declare parameters.

### PaymentRequiredException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/PaymentRequiredException.cs#L15)

Initializes a new `PaymentRequiredException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public PaymentRequiredException(string messageKey, params object? [] args) : base(messageKey, args);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `messageKey` | `string` | `-` | The `messageKey` value passed to this member. |
| `args` | `object?[]` | `-` | The `args` value passed to this member. |

### PaymentRequiredException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/PaymentRequiredException.cs#L19)

Initializes a new `PaymentRequiredException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public PaymentRequiredException(string messageKey, object? [] args, Exception? innerException) : base(messageKey, args, innerException);
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
| [StatusCode](property-statuscode-9.md) | Exposes the `StatusCode` value on `PaymentRequiredException`. Read or set it as part of configuring or using the type. |

