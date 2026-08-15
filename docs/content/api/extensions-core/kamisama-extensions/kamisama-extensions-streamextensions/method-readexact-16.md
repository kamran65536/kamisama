# ReadExact

[Back to StreamExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/StreamExtensions.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/StreamExtensions.cs#L16)

Type: `KamiSama.Extensions.StreamExtensions`

Kind: `Method`

## Description

Reads exactly the requested number of bytes, failing if that count is not reached within the allowed read attempts. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static byte[] ReadExact(this Stream stream, int length, int maxTries = int.MaxValue);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `stream (extension receiver)` | `Stream` | `-` | the stream |
| `length` | `int` | `-` | length of bytes to be read |
| `maxTries` | `int` | `int.MaxValue` | maximum tries default value is int.MaxValue |

## Returns

| Type | Description |
| --- | --- |
| `byte[]` | Returns a `byte[]` value. |

## Example

```csharp
var memStream = new MemoryStream();
```

