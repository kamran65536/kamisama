# FindByIdAsync

[Back to ProvinceRepository](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/Repositories/Implementations/ProvinceRepository.cs:27](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Repositories/Implementations/ProvinceRepository.cs#L27)

Type: `KamiSama.Modules.Locations.Repositories.Implementations.ProvinceRepository`

Kind: `Method`

## Description

Runs the `FindByIdAsync` operation on `ProvinceRepository`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public Task<Province?> FindByIdAsync(Guid id, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `id` | `Guid` | `-` | The `id` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<Province?>` | Returns a `Task<Province?>` value. |

## Example

No concise standalone example is available yet.

