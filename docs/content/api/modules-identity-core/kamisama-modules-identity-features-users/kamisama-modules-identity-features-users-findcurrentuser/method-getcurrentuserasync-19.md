# GetCurrentUserAsync

[Back to FindCurrentUser](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/FindCurrentUser.cs:19](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/FindCurrentUser.cs#L19)

Type: `KamiSama.Modules.Identity.Features.Users.FindCurrentUser`

Kind: `Method`

## Description

Runs the `GetCurrentUserAsync` operation on `FindCurrentUser`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task<UserDto> GetCurrentUserAsync(CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<UserDto>` | Returns a `Task<UserDto>` value. |

## Example

No concise standalone example is available yet.

