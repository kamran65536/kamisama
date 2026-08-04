# Repository

[Back to GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericAddFeature.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericAddFeature.cs#L13)

Type: `KamiSama.Chassis.Commons.Features.GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>`

Kind: `Property`

## Description

Protected repository used by derived feature implementations. Use it inside mapping and validation hooks when the feature needs data access beyond the base add flow.

## Declaration

```csharp
protected TRepository Repository { get => repository; }
```

## Value

| Detail | Description |
| --- | --- |
| `Property` | Gets a `TRepository` value. |

## Example

No concise standalone example is available yet.

