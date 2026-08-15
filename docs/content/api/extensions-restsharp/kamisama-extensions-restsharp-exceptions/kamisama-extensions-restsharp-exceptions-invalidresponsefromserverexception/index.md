# InvalidResponseFromServerException

<a id="invalidresponsefromserverexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.RestSharp](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Extensions.RestSharp/Exceptions/InvalidResponseFromServerException.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/Exceptions/InvalidResponseFromServerException.cs#L9)

Namespace: `KamiSama.Extensions.RestSharp.Exceptions`

Kind: `Class`

## Description

Represents an invalid response received by a UI client from a remote server. This exception uses the application-specific status code `-2` and is not intended for backend HTTP responses.

## Declaration

```csharp
public class InvalidResponseFromServerException(params object[] args) : HttpExceptionBase(nameof(InvalidResponseFromServerException), args)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/Exceptions/InvalidResponseFromServerException.cs#L9)

Represents an invalid response received by a UI client from a remote server. This exception uses the application-specific status code `-2` and is not intended for backend HTTP responses.

```csharp
public class InvalidResponseFromServerException(params object[] args) : HttpExceptionBase(nameof(InvalidResponseFromServerException), args)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `args` | `object[]` | `-` | Values stored as localization arguments for the exception key. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [StatusCode](property-statuscode-14.md) | Gets the application-specific invalid-response status code `-2`. Use it with the surrounding package APIs when composing application code. |

