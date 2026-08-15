# TerminateAsync

[Back to ITerminateSession](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs:31](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs#L31)

Type: `KamiSama.Modules.Identity.Services.AccountSecurity.ITerminateSession`

Kind: `Method`

## Description

Terminates the selected session. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task TerminateAsync(Guid userId, string sessionId, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userId` | `Guid` | `-` | The owner of the session. |
| `sessionId` | `string` | `-` | The public session identifier interpreted by the implementation. |
| `cancellationToken` | `CancellationToken` | `-` | A token that requests cancellation. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | A task that represents the revocation operation. |

## Example

```csharp
await terminateSession.TerminateAsync(userId, sessionId, cancellationToken);
```

