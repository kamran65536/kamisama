# ValidateAsync

[Back to ValidateAuthenticatorCodeIfEnabled](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/ValidateAuthenticatorCodeIfEnabled.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/ValidateAuthenticatorCodeIfEnabled.cs#L11)

Type: `KamiSama.Modules.Identity.Features.Users.ValidateAuthenticatorCodeIfEnabled`

Kind: `Method`

## Description

Runs the `ValidateAsync` operation on `ValidateAuthenticatorCodeIfEnabled`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task ValidateAsync(ApplicationUser user, string? twoFactorCode);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `user` | `ApplicationUser` | `-` | The `user` value passed to this member. |
| `twoFactorCode` | `string?` | `-` | The `twoFactorCode` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

