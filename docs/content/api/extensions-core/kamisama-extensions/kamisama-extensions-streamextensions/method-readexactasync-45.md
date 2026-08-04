# ReadExactAsync

[Back to StreamExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/StreamExtensions.cs:45](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/StreamExtensions.cs#L45)

Type: `KamiSama.Extensions.StreamExtensions`

Kind: `Method`

## Description

Read exact bytes as specified. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static async Task<byte[]> ReadExactAsync(this Stream stream, int length, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `stream (extension receiver)` | `Stream` | `-` | the stream |
| `length` | `int` | `-` | length of bytes to be read |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<byte[]>` | Returns a `Task<byte[]>` value. |

## Example

```csharp
var memStream = new MemoryStream("01020304".FromHex());
memStream.Seek(0, SeekOrigin.Begin);
memStream.Close();
await Assert.ThrowsAsync<Exception>(async () => await memStream.ReadExactAsync(4, CancellationToken.None));
```

