# RevokeBySessionKeyAsync

[Back to IApplicationSessionRepository](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationSessionRepository.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationSessionRepository.cs#L10)

Type: `KamiSama.Modules.Identity.Repositories.Abstractions.IApplicationSessionRepository`

Kind: `Method`

## Description

Runs the `RevokeBySessionKeyAsync` operation on `IApplicationSessionRepository`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task RevokeBySessionKeyAsync(Guid userId, string sessionKey, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userId` | `Guid` | `-` | The `userId` value passed to this member. |
| `sessionKey` | `string` | `-` | The `sessionKey` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

