# GoneException

<a id="goneexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/GoneException.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/GoneException.cs#L5)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

Indicates that the resource requested was previously in use but is no longer available and will not be available again. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class GoneException : HttpExceptionBase
```

## Constructors

### GoneException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/GoneException.cs#L10)

Initializes a new `GoneException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public GoneException();
```

## Parameters

This member does not declare parameters.

### GoneException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/GoneException.cs#L14)

Initializes a new `GoneException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public GoneException(string message, params object? [] args) : base(message, args);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `message` | `string` | `-` | The `message` value passed to this member. |
| `args` | `object?[]` | `-` | The `args` value passed to this member. |

### GoneException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/GoneException.cs#L18)

Initializes a new `GoneException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public GoneException(string messageKey, object? [] args, Exception? innerException) : base(messageKey, args, innerException);
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
| [StatusCode](property-statuscode-8.md) | Exposes the `StatusCode` value on `GoneException`. Read or set it as part of configuring or using the type. |

