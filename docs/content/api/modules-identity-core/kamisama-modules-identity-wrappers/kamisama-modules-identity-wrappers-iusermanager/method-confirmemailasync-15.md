# ConfirmEmailAsync

[Back to IUserManager](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Wrappers/IUserManager.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Wrappers/IUserManager.cs#L15)

Type: `KamiSama.Modules.Identity.Wrappers.IUserManager`

Kind: `Method`

## Description

Runs the `ConfirmEmailAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task ConfirmEmailAsync(ApplicationUser user, string token);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `user` | `ApplicationUser` | `-` | The `user` value passed to this member. |
| `token` | `string` | `-` | The `token` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

