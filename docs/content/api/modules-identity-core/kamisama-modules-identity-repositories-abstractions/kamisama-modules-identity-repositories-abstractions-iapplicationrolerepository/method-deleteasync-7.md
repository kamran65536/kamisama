# DeleteAsync

[Back to IApplicationRoleRepository](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationRoleRepository.cs:7](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationRoleRepository.cs#L7)

Type: `KamiSama.Modules.Identity.Repositories.Abstractions.IApplicationRoleRepository`

Kind: `Method`

## Description

Runs the `DeleteAsync` operation on `IApplicationRoleRepository`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task DeleteAsync(ApplicationRole appRole, CancellationToken cancellationToken);
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
var entity = new SampleEntity { Id = 1, Name = "Test" };
var context = GetDbContext(initialDbSet: [entity]);

var repository = new DbRepository<SampleEntity>(context);

await repository.DeleteAsync(entity, CancellationToken.None);
```

