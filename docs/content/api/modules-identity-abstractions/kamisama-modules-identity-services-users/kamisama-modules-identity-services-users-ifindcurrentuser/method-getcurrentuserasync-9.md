# GetCurrentUserAsync

[Back to IFindCurrentUser](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs#L9)

Type: `KamiSama.Modules.Identity.Services.Users.IFindCurrentUser`

Kind: `Method`

## Description

Returns the current user. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<UserDto> GetCurrentUserAsync(CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cancellationToken` | `CancellationToken` | `-` | A token that requests cancellation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<UserDto>` | The current user&apos;s provider-neutral representation. |

## Example

```csharp
UserDto user = await currentUser.GetCurrentUserAsync(cancellationToken);
```

