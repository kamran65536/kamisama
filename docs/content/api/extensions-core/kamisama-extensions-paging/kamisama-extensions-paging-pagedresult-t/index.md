# PagedResult<T>

<a id="pagedresult-t"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Extensions.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/Core/Paging/PagedResult.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/Paging/PagedResult.cs#L12)

Namespace: `KamiSama.Extensions.Paging`

Kind: `Record`

## Description

Provides the `PagedResult<T>` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public record PagedResult<T>(int TotalItemsCount, List<T> Items)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Core/Paging/PagedResult.cs#L12)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public record PagedResult<T>(int TotalItemsCount, List<T> Items)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `TotalItemsCount` | `int` | `-` | The `TotalItemsCount` value passed to this member. |
| `Items` | `List<T>` | `-` | The `Items` value passed to this member. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [ConvertTo<TOtherType>](method-convertto-tothertype-24.md) | Converts a paged result to another one. Use it with the surrounding package APIs when composing application code. |
| [ConvertToAsync<TOtherType>](method-converttoasync-tothertype-29.md) | Converts a paged result to another one asynchronously. Use it with the surrounding package APIs when composing application code. |

### Properties

| Member | Description |
| --- | --- |
| [Empty](property-empty-17.md) | Exposes the `Empty` value on `PagedResult<T>`. Read or set it as part of configuring or using the type. |

