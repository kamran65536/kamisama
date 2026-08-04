# RequestTimedOutException

<a id="requesttimedoutexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.RestSharp](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Extensions.RestSharp/Exceptions/RequestTimedOutException.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/Exceptions/RequestTimedOutException.cs#L7)

Namespace: `KamiSama.Extensions.RestSharp.Exceptions`

Kind: `Class`

## Description

This is a UI response exception and should not be used in backend. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public class RequestTimedOutException() : HttpExceptionBase(nameof(RequestTimedOutException))
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/Exceptions/RequestTimedOutException.cs#L7)

This is a UI response exception and should not be used in backend. Use it with the surrounding package APIs when composing application code.

```csharp
public class RequestTimedOutException() : HttpExceptionBase(nameof(RequestTimedOutException))
```

## Parameters

This member does not declare parameters.

## Members

### Properties

| Member | Description |
| --- | --- |
| [StatusCode](property-statuscode-9.md) | Exposes the `StatusCode` value on `RequestTimedOutException`. Read or set it as part of configuring or using the type. |

