# AddFile

[Back to IRestBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.RestSharp](../../index.md)

Source: [src/KamiSama.Extensions.RestSharp/IRestBuilder.cs:48](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.RestSharp/IRestBuilder.cs#L48)

Type: `KamiSama.Extensions.RestSharp.IRestBuilder`

Kind: `Method`

## Description

Adds an in-memory file to the current multipart request. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
IRestBuilder AddFile(string filename, byte[] data);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `filename` | `string` | `-` | The form field and file name sent to the remote service. |
| `data` | `byte[]` | `-` | The complete file content. |

## Returns

| Type | Description |
| --- | --- |
| `IRestBuilder` | The same builder so request configuration can be chained. |

## Example

No concise standalone example is available yet.

