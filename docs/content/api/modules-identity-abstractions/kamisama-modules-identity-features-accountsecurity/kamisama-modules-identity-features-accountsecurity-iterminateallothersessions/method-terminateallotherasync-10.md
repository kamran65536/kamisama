# TerminateAllOtherAsync

[Back to ITerminateAllOtherSessions](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/AccountSecurity/Features.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/AccountSecurity/Features.cs#L10)

Type: `KamiSama.Modules.Identity.Features.AccountSecurity.ITerminateAllOtherSessions`

Kind: `Method`

## Description

Runs the `TerminateAllOtherAsync` operation on `ITerminateAllOtherSessions`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task TerminateAllOtherAsync(Guid userId, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userId` | `Guid` | `-` | The `userId` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

