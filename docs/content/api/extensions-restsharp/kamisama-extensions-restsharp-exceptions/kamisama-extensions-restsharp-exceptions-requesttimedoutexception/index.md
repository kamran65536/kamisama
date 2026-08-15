# RequestTimedOutException

<a id="requesttimedoutexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.RestSharp](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Extensions.RestSharp/Exceptions/RequestTimedOutException.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/Exceptions/RequestTimedOutException.cs#L8)

Namespace: `KamiSama.Extensions.RestSharp.Exceptions`

Kind: `Class`

## Description

Represents a remote request timeout reported to a UI client. This exception uses the application-specific status code `-1` and is not intended for backend HTTP responses.

## Declaration

```csharp
public class RequestTimedOutException() : HttpExceptionBase(nameof(RequestTimedOutException))
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/Exceptions/RequestTimedOutException.cs#L8)

Represents a remote request timeout reported to a UI client. This exception uses the application-specific status code `-1` and is not intended for backend HTTP responses.

```csharp
public class RequestTimedOutException() : HttpExceptionBase(nameof(RequestTimedOutException))
```

## Parameters

This member does not declare parameters.

## Members

### Properties

| Member | Description |
| --- | --- |
| [StatusCode](property-statuscode-13.md) | Gets the application-specific request-timeout status code `-1`. Use it with the surrounding package APIs when composing application code. |

