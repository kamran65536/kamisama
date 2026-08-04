# AddAsync

[Back to IApplicationRoleRepository](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationRoleRepository.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationRoleRepository.cs#L6)

Type: `KamiSama.Modules.Identity.Repositories.Abstractions.IApplicationRoleRepository`

Kind: `Method`

## Description

Runs the `AddAsync` operation on `IApplicationRoleRepository`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task AddAsync(ApplicationRole appRole, CancellationToken cancellationToken);
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
var repository = new InMemoryRepository<SampleEntity>();

await repository.AddAsync(sample, CancellationToken.None);
```

