# DequeueOrDefault<TItem>

[Back to QueueExtensions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/QueueExtensions.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/QueueExtensions.cs#L15)

Type: `KamiSama.Extensions.QueueExtensions`

Kind: `Method`

## Description

Dequeues or return default value for item. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public static TItem? DequeueOrDefault<TItem>(this Queue<TItem> queue, TItem? defaultValue = default);
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TItem` |  |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `queue (extension receiver)` | `Queue<TItem>` | `-` | The `queue` value passed to this member. |
| `defaultValue` | `TItem?` | `default` | The `defaultValue` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `TItem?` | the item or default value if queue is empty |

## Example

```csharp
var queue = new Queue<int>();
```

