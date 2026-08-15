# ListAsync

[Back to IListFeature<TEntityDto, TSearchModel, TPageResult>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IListFeature.cs:19](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IListFeature.cs#L19)

Type: `KamiSama.Chassis.Commons.Features.IListFeature<TEntityDto, TSearchModel, TPageResult>`

Kind: `Method`

## Description

Searches for matching items and returns the requested page. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<TPageResult> ListAsync(TSearchModel searchModel, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `searchModel` | `TSearchModel` | `-` | The filtering and paging values. |
| `cancellationToken` | `CancellationToken` | `-` | A token that can cancel the operation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TPageResult>` | A page of matching DTOs. |

## Example

No concise standalone example is available yet.

