# UpdateAsync

[Back to IApplicationRoleRepository](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationRoleRepository.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationRoleRepository.cs#L9)

Type: `KamiSama.Modules.Identity.Repositories.Abstractions.IApplicationRoleRepository`

Kind: `Method`

## Description

Runs the `UpdateAsync` operation on `IApplicationRoleRepository`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task UpdateAsync(ApplicationRole appRole, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `appRole` | `ApplicationRole` | `-` | The `appRole` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

```csharp
var sample = new SampleEntity { Id = 1, Name = "sample" };
var repository = new InMemoryRepository<SampleEntity>([sample]);

sample.Name = "sample2";

await repository.UpdateAsync(sample, CancellationToken.None);

var retrieved = repository.Find(x => x.Name == "sample2");
```

