# HttpExceptionBase

<a id="httpexceptionbase"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Chassis.HttpExceptions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Chassis.Exceptions/HttpExceptionBase.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/HttpExceptionBase.cs#L11)

Namespace: `KamiSama.Chassis.HttpExceptions`

Kind: `Class`

## Description

base Exception class for all Janus Services. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public abstract class HttpExceptionBase : Exception
```

## Constructors

### HttpExceptionBase

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/HttpExceptionBase.cs#L31)

Initializes a new `HttpExceptionBase` instance. Use it with the surrounding package APIs when composing application code.

```csharp
protected HttpExceptionBase();
```

## Parameters

This member does not declare parameters.

### HttpExceptionBase

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/HttpExceptionBase.cs#L36)

Initializes a new `HttpExceptionBase` instance. Use it with the surrounding package APIs when composing application code.

```csharp
protected HttpExceptionBase(string messageKey, params object? [] args) : base(TryFormatString(messageKey, args));
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `messageKey` | `string` | `-` | The `messageKey` value passed to this member. |
| `args` | `object?[]` | `-` | The `args` value passed to this member. |

### HttpExceptionBase

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Exceptions/HttpExceptionBase.cs#L42)

Initializes a new `HttpExceptionBase` instance. Use it with the surrounding package APIs when composing application code.

```csharp
protected HttpExceptionBase(string messageKey, object? [] args, Exception? innerException) : base(TryFormatString(messageKey, args), innerException);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `messageKey` | `string` | `-` | The `messageKey` value passed to this member. |
| `args` | `object?[]` | `-` | The `args` value passed to this member. |
| `innerException` | `Exception?` | `-` | The `innerException` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [TryFormatString](method-tryformatstring-53.md) | Runs the `TryFormatString` operation on `HttpExceptionBase`. Use it when your code needs this specific behavior from the package. |

### Properties

| Member | Description |
| --- | --- |
| [ExceptionLocalizationArguments](property-exceptionlocalizationarguments-25.md) | Exception localization arguments. Use it with the surrounding package APIs when composing application code. |
| [ExceptionLocalizationKey](property-exceptionlocalizationkey-21.md) | Exception localization key for localization. Use it with the surrounding package APIs when composing application code. |
| [ExtendedProperties](property-extendedproperties-29.md) | Extended properties for Problem Details error handling. Use it with the surrounding package APIs when composing application code. |
| [StatusCode](property-statuscode-17.md) | HTTP Status code to return. Use it with the surrounding package APIs when composing application code. |

