# DisableAsync

[Back to IDisable2fa](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs:24](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs#L24)

Type: `KamiSama.Modules.Identity.Services.Users.IDisable2fa`

Kind: `Method`

## Description

Disables two-factor authentication for the specified user. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task DisableAsync(Guid userId, CancellationToken cancellationToken);
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
await disable2fa.DisableAsync(userId, cancellationToken);
```

