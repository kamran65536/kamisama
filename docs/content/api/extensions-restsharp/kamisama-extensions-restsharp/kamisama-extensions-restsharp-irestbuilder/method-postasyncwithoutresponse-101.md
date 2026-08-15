# PostAsyncWithoutResponse

[Back to IRestBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.RestSharp](../../index.md)

Source: [src/KamiSama.Extensions.RestSharp/IRestBuilder.cs:101](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/IRestBuilder.cs#L101)

Type: `KamiSama.Extensions.RestSharp.IRestBuilder`

Kind: `Method`

## Description

Sends the current request with POST without deserializing a response body. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task PostAsyncWithoutResponse(CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cancellationToken` | `CancellationToken` | `-` | The token used to cancel the HTTP operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task representing the HTTP operation. |

## Example

No concise standalone example is available yet.

