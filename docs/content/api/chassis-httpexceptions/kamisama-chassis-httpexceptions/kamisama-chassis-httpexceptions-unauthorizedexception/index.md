# UnAuthorizedException

<a id="unauthorizedexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/UnAuthorizedException.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/UnAuthorizedException.cs#L8)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

Thrown when the operation requested is not authorized. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class UnAuthorizedException : HttpExceptionBase
```

## Constructors

### UnAuthorizedException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/UnAuthorizedException.cs#L14)

Initializes a new `UnAuthorizedException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public UnAuthorizedException();
```

## Parameters

This member does not declare parameters.

### UnAuthorizedException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/UnAuthorizedException.cs#L18)

Initializes a new `UnAuthorizedException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public UnAuthorizedException(string messageKey, params object? [] args) : base(messageKey, args);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `messageKey` | `string` | `-` | The `messageKey` value passed to this member. |
| `args` | `object?[]` | `-` | The `args` value passed to this member. |

### UnAuthorizedException

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/UnAuthorizedException.cs#L22)

Initializes a new `UnAuthorizedException` instance. Use it with the surrounding package APIs when composing application code.

```csharp
public UnAuthorizedException(string messageKey, object? [] args, Exception? innerException) : base(messageKey, args, innerException);
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
| [StatusCode](property-statuscode-12.md) | Exposes the `StatusCode` value on `UnAuthorizedException`. Read or set it as part of configuring or using the type. |

