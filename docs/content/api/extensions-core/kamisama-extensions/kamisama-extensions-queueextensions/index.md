# QueueExtensions

<a id="queueextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Core/QueueExtensions.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/QueueExtensions.cs#L7)

Namespace: `KamiSama.Extensions`

Kind: `Class`

## Description

Provides extensions for safely dequeuing a value or returning a fallback when a queue is empty. Use them when an empty queue is an expected condition rather than an error.

## Declaration

```csharp
public static class QueueExtensions
```

## Example

```csharp
var queue = new Queue<string>();
string value = queue.DequeueOrDefault("none"); // none
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [DequeueOrDefault<TItem>](method-dequeueordefault-titem-16.md) | Dequeues and returns the next item, or returns the specified fallback when the queue is empty. Use it with the surrounding package APIs when composing application code. |

