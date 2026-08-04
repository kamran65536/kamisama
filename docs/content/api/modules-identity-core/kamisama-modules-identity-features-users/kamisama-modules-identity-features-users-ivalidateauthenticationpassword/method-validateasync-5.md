# ValidateAsync

[Back to IValidateAuthenticationPassword](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/ValidateAuthenticationPassword.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/ValidateAuthenticationPassword.cs#L5)

Type: `KamiSama.Modules.Identity.Features.Users.IValidateAuthenticationPassword`

Kind: `Method`

## Description

Runs the `ValidateAsync` operation on `IValidateAuthenticationPassword`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task ValidateAsync(ApplicationUser user, string password);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `user` | `ApplicationUser` | `-` | The `user` value passed to this member. |
| `password` | `string` | `-` | The `password` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

