# PagedResult<T>

<a id="pagedresult-t"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Core/Paging/PagedResult.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/Paging/PagedResult.cs#L13)

Namespace: `KamiSama.Extensions.Paging`

Kind: `Record`

## Description

Represents one materialized page of items together with the total number of matching items. Use it to return page data without losing the count needed by callers to render pagination.

## Declaration

```csharp
public record PagedResult<T>(int TotalItemsCount, List<T> Items)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/Paging/PagedResult.cs#L13)

Represents one materialized page of items together with the total number of matching items. Use it to return page data without losing the count needed by callers to render pagination.

```csharp
public record PagedResult<T>(int TotalItemsCount, List<T> Items)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `TotalItemsCount` | `int` | `-` | The total number of matching items across all pages. |
| `Items` | `List<T>` | `-` | The items materialized for this page. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ConvertTo<TOtherType>](method-convertto-tothertype-25.md) | Projects each item to another type while preserving the total item count. Use it with the surrounding package APIs when composing application code. |
| [ConvertToAsync<TOtherType>](method-converttoasync-tothertype-30.md) | Asynchronously projects each item to another type while preserving the total item count. Use it with the surrounding package APIs when composing application code. |

### Properties

| Member | Description |
| --- | --- |
| [Empty](property-empty-18.md) | Gets an empty paged result with a total count of zero. Use it with the surrounding package APIs when composing application code. |

