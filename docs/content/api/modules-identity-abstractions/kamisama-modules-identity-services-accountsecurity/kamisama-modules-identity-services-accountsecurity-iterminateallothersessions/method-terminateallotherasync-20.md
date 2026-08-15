# TerminateAllOtherAsync

[Back to ITerminateAllOtherSessions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs:20](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs#L20)

Type: `KamiSama.Modules.Identity.Services.AccountSecurity.ITerminateAllOtherSessions`

Kind: `Method`

## Description

Terminates all other sessions for the specified user. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task TerminateAllOtherAsync(Guid userId, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userId` | `Guid` | `-` | The user whose other sessions are revoked. |
| `cancellationToken` | `CancellationToken` | `-` | A token that requests cancellation. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that represents the revocation operation. |

## Example

```csharp
await terminateAllOtherSessions.TerminateAllOtherAsync(userId, cancellationToken);
```

