# ConvertTo<TOtherType>

[Back to PagedResult<T>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md)

Source: [src/Core/Paging/PagedResult.cs:24](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/Paging/PagedResult.cs#L24)

Type: `KamiSama.Extensions.Paging.PagedResult<T>`

Kind: `Method`

## Description

Converts a paged result to another one. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public virtual PagedResult<TOtherType> ConvertTo<TOtherType>(Func<T, TOtherType> convertFunc);
```

## Type Parameters

| Name | Description |
| --- | --- |
| `TOtherType` |  |

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `convertFunc` | `Func<T, TOtherType>` | `-` | The `convertFunc` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `PagedResult<TOtherType>` | Returns a `PagedResult<TOtherType>` value. |

## Example

```csharp
using KamiSama.Extensions.Paging;

var page = new PagedResult<int>(3, [1, 2, 3]);
var textPage = page.ConvertTo(x => x.ToString());
```

