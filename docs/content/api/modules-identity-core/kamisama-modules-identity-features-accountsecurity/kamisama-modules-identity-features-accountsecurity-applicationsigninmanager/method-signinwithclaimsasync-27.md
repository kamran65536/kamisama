# SignInWithClaimsAsync

[Back to ApplicationSignInManager](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ApplicationSignInManager.cs:27](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ApplicationSignInManager.cs#L27)

Type: `KamiSama.Modules.Identity.Features.AccountSecurity.ApplicationSignInManager`

Kind: `Method`

## Description

Runs the `SignInWithClaimsAsync` operation on `ApplicationSignInManager`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public override async Task SignInWithClaimsAsync(ApplicationUser user, AuthenticationProperties? authenticationProperties, IEnumerable<Claim> additionalClaims);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `user` | `ApplicationUser` | `-` | The `user` value passed to this member. |
| `authenticationProperties` | `AuthenticationProperties?` | `-` | The `authenticationProperties` value passed to this member. |
| `additionalClaims` | `IEnumerable<Claim>` | `-` | The `additionalClaims` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

