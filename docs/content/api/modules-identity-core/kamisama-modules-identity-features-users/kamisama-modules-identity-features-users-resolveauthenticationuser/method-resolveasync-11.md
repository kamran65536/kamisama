# ResolveAsync

[Back to ResolveAuthenticationUser](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/ResolveAuthenticationUser.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/ResolveAuthenticationUser.cs#L11)

Type: `KamiSama.Modules.Identity.Features.Users.ResolveAuthenticationUser`

Kind: `Method`

## Description

Runs the `ResolveAsync` operation on `ResolveAuthenticationUser`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task<ApplicationUser> ResolveAsync(AuthenticateUserRequest request, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `request` | `AuthenticateUserRequest` | `-` | The `request` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<ApplicationUser>` | Returns a `Task<ApplicationUser>` value. |

## Example

No concise standalone example is available yet.

