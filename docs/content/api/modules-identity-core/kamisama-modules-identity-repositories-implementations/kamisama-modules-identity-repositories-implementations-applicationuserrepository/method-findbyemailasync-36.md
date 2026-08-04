# FindByEmailAsync

[Back to ApplicationUserRepository](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Repositories/Implementations/ApplicationUserRepository.cs:36](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Implementations/ApplicationUserRepository.cs#L36)

Type: `KamiSama.Modules.Identity.Repositories.Implementations.ApplicationUserRepository`

Kind: `Method`

## Description

Runs the `FindByEmailAsync` operation on `ApplicationUserRepository`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public Task<ApplicationUser?> FindByEmailAsync(string email, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `email` | `string` | `-` | The `email` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<ApplicationUser?>` | Returns a `Task<ApplicationUser?>` value. |

## Example

No concise standalone example is available yet.

