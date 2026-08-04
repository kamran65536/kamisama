# ConflictException

<a id="conflictexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/ConflictException.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/ConflictException.cs#L6)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

Indicates that the request could not be processed because of conflict in the current state of the resource, such as an edit conflict between multiple simultaneous updates. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class ConflictException : HttpExceptionBase
```

## Constructors

### ConflictException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/ConflictException.cs#L11)

Initializes a new `ConflictException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public ConflictException();
```

## Parameters

This member does not declare parameters.

### ConflictException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/ConflictException.cs#L15)

Initializes a new `ConflictException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public ConflictException(string messageKey, params object? [] args) : base(messageKey, args);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `messageKey` | `string` | `-` | The `messageKey` value passed to this member. |
| `args` | `object?[]` | `-` | The `args` value passed to this member. |

### ConflictException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/ConflictException.cs#L19)

Initializes a new `ConflictException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public ConflictException(string messageKey, object? [] args, Exception? innerException) : base(messageKey, args, innerException);
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
| [StatusCode](property-statuscode-9.md) | Exposes the `StatusCode` value on `ConflictException`. Read or set it as part of configuring or using the type. |

