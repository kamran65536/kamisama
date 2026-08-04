# ValidateAsync

[Back to IValidateAuthenticatorCodeIfEnabled](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/ValidateAuthenticatorCodeIfEnabled.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/ValidateAuthenticatorCodeIfEnabled.cs#L5)

Type: `KamiSama.Modules.Identity.Features.Users.IValidateAuthenticatorCodeIfEnabled`

Kind: `Method`

## Description

Runs the `ValidateAsync` operation on `IValidateAuthenticatorCodeIfEnabled`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task ValidateAsync(ApplicationUser user, string? twoFactorCode);
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

