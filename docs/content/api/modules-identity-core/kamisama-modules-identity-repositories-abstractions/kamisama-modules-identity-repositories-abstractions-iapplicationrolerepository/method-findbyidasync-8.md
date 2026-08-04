# FindByIdAsync

[Back to IApplicationRoleRepository](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationRoleRepository.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationRoleRepository.cs#L8)

Type: `KamiSama.Modules.Identity.Repositories.Abstractions.IApplicationRoleRepository`

Kind: `Method`

## Description

Runs the `FindByIdAsync` operation on `IApplicationRoleRepository`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<ApplicationRole?> FindByIdAsync(Guid Id, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Id` | `Guid` | `-` | The `Id` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<ApplicationRole?>` | Returns a `Task<ApplicationRole?>` value. |

## Example

No concise standalone example is available yet.

