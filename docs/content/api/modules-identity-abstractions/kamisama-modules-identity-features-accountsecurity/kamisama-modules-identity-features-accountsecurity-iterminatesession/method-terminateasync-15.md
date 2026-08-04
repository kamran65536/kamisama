# TerminateAsync

[Back to ITerminateSession](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/AccountSecurity/Features.cs:15](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/AccountSecurity/Features.cs#L15)

Type: `KamiSama.Modules.Identity.Features.AccountSecurity.ITerminateSession`

Kind: `Method`

## Description

Runs the `TerminateAsync` operation on `ITerminateSession`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task TerminateAsync(Guid userId, string sessionId, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userId` | `Guid` | `-` | The `userId` value passed to this member. |
| `sessionId` | `string` | `-` | The `sessionId` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

