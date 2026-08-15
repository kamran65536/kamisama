# ListAsync

[Back to IListActiveSessions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/AccountSecurity/Features.cs#L10)

Type: `KamiSama.Modules.Identity.Services.AccountSecurity.IListActiveSessions`

Kind: `Method`

## Description

Returns active sessions for the specified user. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
Task<IReadOnlyList<ActiveSessionDto>> ListAsync(Guid userId, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userId` | `Guid` | `-` | The user whose sessions are requested. |
| `cancellationToken` | `CancellationToken` | `-` | A token that requests cancellation. |

## Returns

| Type | Description |
| --- | --- |
| `Task<IReadOnlyList<ActiveSessionDto>>` | The active sessions in implementation-defined order. |

## Example

```csharp
IReadOnlyList<ActiveSessionDto> sessions = await listActiveSessions.ListAsync(userId, cancellationToken);
```

