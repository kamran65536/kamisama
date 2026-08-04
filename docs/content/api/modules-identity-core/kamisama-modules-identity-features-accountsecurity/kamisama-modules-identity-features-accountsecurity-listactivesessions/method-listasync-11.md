# ListAsync

[Back to ListActiveSessions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ListActiveSessions.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ListActiveSessions.cs#L11)

Type: `KamiSama.Modules.Identity.Features.AccountSecurity.ListActiveSessions`

Kind: `Method`

## Description

Runs the `ListAsync` operation on `ListActiveSessions`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task<IReadOnlyList<ActiveSessionDto>> ListAsync(Guid userId, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userId` | `Guid` | `-` | The `userId` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<IReadOnlyList<ActiveSessionDto>>` | Returns a `Task<IReadOnlyList<ActiveSessionDto>>` value. |

## Example

No concise standalone example is available yet.

