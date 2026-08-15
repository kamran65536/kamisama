# StreamExtensions

<a id="streamextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Core/StreamExtensions.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/StreamExtensions.cs#L7)

Namespace: `KamiSama.Extensions`

Kind: `Class`

## Description

Provides synchronous and asynchronous helpers for reading an exact number of bytes from a stream. The helpers fail when the requested byte count cannot be obtained.

## Declaration

```csharp
public static class StreamExtensions
```

## Example

```csharp
using var stream = new MemoryStream([1, 2, 3, 4]);
byte[] header = stream.ReadExact(2); // [1, 2]
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ReadExact](method-readexact-16.md) | Reads exactly the requested number of bytes, failing if that count is not reached within the allowed read attempts. Use it with the surrounding package APIs when composing application code. |
| [ReadExactAsync](method-readexactasync-46.md) | Asynchronously reads exactly the requested number of bytes unless the operation is canceled or the required count cannot be reached. Use it with the surrounding package APIs when composing application code. |

