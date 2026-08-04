# ListAsync

[Back to IListingRepository<TEntity, TSearchModel, TPagedResult>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Repositories/IListingRepository.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Repositories/IListingRepository.cs#L13)

Type: `KamiSama.Chassis.Commons.Repositories.IListingRepository<TEntity, TSearchModel, TPagedResult>`

Kind: `Method`

## Description

Lists items and page them. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<TPagedResult> ListAsync(TSearchModel searchModel, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `searchModel` | `TSearchModel` | `-` | The `searchModel` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TPagedResult>` | Returns a `Task<TPagedResult>` value. |

## Example

No concise standalone example is available yet.

