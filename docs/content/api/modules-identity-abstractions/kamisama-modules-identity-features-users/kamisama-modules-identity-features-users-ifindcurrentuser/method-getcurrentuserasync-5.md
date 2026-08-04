# GetCurrentUserAsync

[Back to IFindCurrentUser](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/Users/Features.cs:5](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Users/Features.cs#L5)

Type: `KamiSama.Modules.Identity.Features.Users.IFindCurrentUser`

Kind: `Method`

## Description

Runs the `GetCurrentUserAsync` operation on `IFindCurrentUser`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<UserDto> GetCurrentUserAsync(CancellationToken cancellationToken);
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

