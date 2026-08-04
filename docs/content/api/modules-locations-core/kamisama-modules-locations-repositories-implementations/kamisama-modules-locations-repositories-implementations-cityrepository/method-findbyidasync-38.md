# FindByIdAsync

[Back to CityRepository](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Locations.Core](../../index.md)

Source: [src/KamiSama.Modules.Locations.Core/Repositories/Implementations/CityRepository.cs:38](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Locations.Core/Repositories/Implementations/CityRepository.cs#L38)

Type: `KamiSama.Modules.Locations.Repositories.Implementations.CityRepository`

Kind: `Method`

## Description

Runs the `FindByIdAsync` operation on `CityRepository`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public Task<City?> FindByIdAsync(Guid id, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `id` | `Guid` | `-` | The `id` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<City?>` | Returns a `Task<City?>` value. |

## Example

No concise standalone example is available yet.

