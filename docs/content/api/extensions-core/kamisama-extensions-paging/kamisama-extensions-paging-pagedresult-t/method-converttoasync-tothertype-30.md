# ConvertToAsync<TOtherType>

[Back to PagedResult<T>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/Paging/PagedResult.cs:30](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/Paging/PagedResult.cs#L30)

Type: `KamiSama.Extensions.Paging.PagedResult<T>`

Kind: `Method`

## Description

Asynchronously projects each item to another type while preserving the total item count. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public virtual async Task<PagedResult<TOtherType>> ConvertToAsync<TOtherType>(Func<T, CancellationToken, Task<TOtherType>> convertFunc, CancellationToken cancellationToken);
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TOtherType` | The `TOtherType` generic type argument. |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `convertFunc` | `Func<T, CancellationToken, Task<TOtherType>>` | `-` | The `convertFunc` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<PagedResult<TOtherType>>` | Returns a `Task<PagedResult<TOtherType>>` value. |

## Example

No concise standalone example is available yet.

