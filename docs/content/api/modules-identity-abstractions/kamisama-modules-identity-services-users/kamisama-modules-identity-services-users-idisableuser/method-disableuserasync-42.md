# DisableUserAsync

[Back to IDisableUser](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs:42](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs#L42)

Type: `KamiSama.Modules.Identity.Services.Users.IDisableUser`

Kind: `Method`

## Description

Disables the specified user. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task DisableUserAsync(Guid userId, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userId` | `Guid` | `-` | The target user identifier. |
| `cancellationToken` | `CancellationToken` | `-` | A token that requests cancellation. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that represents the update. |

## Example

```csharp
await disableUser.DisableUserAsync(userId, cancellationToken);
```

