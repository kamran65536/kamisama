# AddQueryParameter

[Back to IRestBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.RestSharp](../../index.md)

Source: [src/KamiSama.Extensions.RestSharp/IRestBuilder.cs:33](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/IRestBuilder.cs#L33)

Type: `KamiSama.Extensions.RestSharp.IRestBuilder`

Kind: `Method`

## Description

Adds the public properties of an object as query parameters on the current request. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
IRestBuilder AddQueryParameter(object queryParams);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `queryParams` | `object` | `-` | The object whose public properties supply query parameter names and values. |

## Returns

| Type | Description |
| --- | --- |
| `IRestBuilder` | The same builder so request configuration can be chained. |

## Example

No concise standalone example is available yet.

