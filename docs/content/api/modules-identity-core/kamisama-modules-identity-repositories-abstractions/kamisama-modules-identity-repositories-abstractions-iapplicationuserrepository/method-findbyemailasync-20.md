# FindByEmailAsync

[Back to IApplicationUserRepository](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationUserRepository.cs:20](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationUserRepository.cs#L20)

Type: `KamiSama.Modules.Identity.Repositories.Abstractions.IApplicationUserRepository`

Kind: `Method`

## Description

Finds a user by email through the configured Identity user manager. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<ApplicationUser?> FindByEmailAsync(string email, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `email` | `string` | `-` | The email address to look up. |
| `cancellationToken` | `CancellationToken` | `-` | A token that requests cancellation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<ApplicationUser?>` | The matching user, or . |

## Example

No concise standalone example is available yet.

