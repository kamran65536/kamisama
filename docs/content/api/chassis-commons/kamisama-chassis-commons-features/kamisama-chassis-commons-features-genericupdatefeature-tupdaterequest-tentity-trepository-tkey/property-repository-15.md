# Repository

[Back to GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Chassis.Commons](../../index.md)

Source: [src/Chassis.Commons/Features/GenericUpdateFeature.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/Chassis.Commons/Features/GenericUpdateFeature.cs#L15)

Type: `KamiSama.Chassis.Commons.Features.GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>`

Kind: `Property`

## Description

Protected repository used by derived update features. Use it when duplicate checks or patching need repository access.

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

