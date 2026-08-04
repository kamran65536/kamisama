# ConvertToPagedResultAsync

[Back to ListUsers](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/ListUsers.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/ListUsers.cs#L17)

Type: `KamiSama.Modules.Identity.Features.Users.ListUsers`

Kind: `Method`

## Description

This method is overridden as concurrent access to `IUserManager.GetRolesAsync(ApplicationUser)` is not possible. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
protected override async Task<PagedResult<UserDto>> ConvertToPagedResultAsync(PagedResult<ApplicationUser> result, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `result` | `PagedResult<ApplicationUser>` | `-` | The `result` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<PagedResult<UserDto>>` | Returns a `Task<PagedResult<UserDto>>` value. |

## Example

No concise standalone example is available yet.

