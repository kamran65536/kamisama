# UnProcessableEntityException

<a id="unprocessableentityexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/UnProcessableEntityException.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/UnProcessableEntityException.cs#L6)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

The request was well-formed but was unable to be followed due to semantic errors. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class UnProcessableEntityException : HttpExceptionBase
```

## Constructors

### UnProcessableEntityException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/UnProcessableEntityException.cs#L11)

Initializes a new `UnProcessableEntityException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public UnProcessableEntityException();
```

## Parameters

This member does not declare parameters.

### UnProcessableEntityException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/UnProcessableEntityException.cs#L15)

Initializes a new `UnProcessableEntityException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public UnProcessableEntityException(string messageKey, params object? [] args) : base(messageKey, args);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `messageKey` | `string` | `-` | The `messageKey` value passed to this member. |
| `args` | `object?[]` | `-` | The `args` value passed to this member. |

### UnProcessableEntityException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/UnProcessableEntityException.cs#L19)

Initializes a new `UnProcessableEntityException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public UnProcessableEntityException(string messageKey, object? [] args, Exception? innerException) : base(messageKey, args, innerException);
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
| [StatusCode](property-statuscode-9.md) | Exposes the `StatusCode` value on `UnProcessableEntityException`. Read or set it as part of configuring or using the type. |

