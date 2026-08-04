# WithBody

[Back to IRestBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.RestSharp](../../index.md)

Source: [src/KamiSama.Extensions.RestSharp/IRestBuilder.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/IRestBuilder.cs#L12)

Type: `KamiSama.Extensions.RestSharp.IRestBuilder`

Kind: `Method`

## Description

Runs the `WithBody` operation on `IRestBuilder`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
IRestBuilder WithBody(object body, string contentType = "application/json");
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `body` | `object` | `-` | The `body` value passed to this member. |
| `contentType` | `string` | `"application/json"` | The `contentType` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `IRestBuilder` | Returns a `IRestBuilder` value. |

## Example

No concise standalone example is available yet.

