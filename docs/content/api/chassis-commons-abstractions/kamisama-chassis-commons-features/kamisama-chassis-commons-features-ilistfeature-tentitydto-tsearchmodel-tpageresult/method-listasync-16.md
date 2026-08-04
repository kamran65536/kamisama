# ListAsync

[Back to IListFeature<TEntityDto, TSearchModel, TPageResult>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons.Abstractions](../../index.md)

Source: [src/Chassis.Commons.Abstractions/Features/IListFeature.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons.Abstractions/Features/IListFeature.cs#L16)

Type: `KamiSama.Chassis.Commons.Features.IListFeature<TEntityDto, TSearchModel, TPageResult>`

Kind: `Method`

## Description

Runs the `ListAsync` operation on `IListFeature<TEntityDto, TSearchModel, TPageResult>`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<TPageResult> ListAsync(TSearchModel searchModel, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `searchModel` | `TSearchModel` | `-` | The `searchModel` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<TPageResult>` | Returns a `Task<TPageResult>` value. |

## Example

No concise standalone example is available yet.

