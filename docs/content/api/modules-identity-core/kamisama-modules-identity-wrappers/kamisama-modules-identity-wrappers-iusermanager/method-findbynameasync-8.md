# FindByNameAsync

[Back to IUserManager](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Wrappers/IUserManager.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Wrappers/IUserManager.cs#L8)

Type: `KamiSama.Modules.Identity.Wrappers.IUserManager`

Kind: `Method`

## Description

Runs the `FindByNameAsync` operation on `IUserManager`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<ApplicationUser?> FindByNameAsync(string username);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `username` | `string` | `-` | The `username` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<ApplicationUser?>` | Returns a `Task<ApplicationUser?>` value. |

## Example

No concise standalone example is available yet.

