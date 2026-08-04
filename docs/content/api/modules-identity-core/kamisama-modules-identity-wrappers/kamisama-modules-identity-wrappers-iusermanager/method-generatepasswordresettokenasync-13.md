# GeneratePasswordResetTokenAsync

[Back to IUserManager](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Wrappers/IUserManager.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Wrappers/IUserManager.cs#L13)

Type: `KamiSama.Modules.Identity.Wrappers.IUserManager`

Kind: `Method`

## Description

Runs the `GeneratePasswordResetTokenAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `user` | `ApplicationUser` | `-` | The `user` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<string>` | Returns a `Task<string>` value. |

## Example

No concise standalone example is available yet.

