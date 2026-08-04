# ListAsync

[Back to IApplicationRoleRepository](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationRoleRepository.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationRoleRepository.cs#L10)

Type: `KamiSama.Modules.Identity.Repositories.Abstractions.IApplicationRoleRepository`

Kind: `Method`

## Description

Runs the `ListAsync` operation on `IApplicationRoleRepository`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<PagedResult<ApplicationRole>> ListAsync(SearchModel searchModel, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `searchModel` | `SearchModel` | `-` | The `searchModel` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<PagedResult<ApplicationRole>>` | Returns a `Task<PagedResult<ApplicationRole>>` value. |

## Example

No concise standalone example is available yet.

