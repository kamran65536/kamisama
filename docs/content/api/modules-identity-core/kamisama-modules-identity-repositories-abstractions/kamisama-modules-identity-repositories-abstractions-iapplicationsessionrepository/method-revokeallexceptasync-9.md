# RevokeAllExceptAsync

[Back to IApplicationSessionRepository](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationSessionRepository.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationSessionRepository.cs#L9)

Type: `KamiSama.Modules.Identity.Repositories.Abstractions.IApplicationSessionRepository`

Kind: `Method`

## Description

Runs the `RevokeAllExceptAsync` operation on `IApplicationSessionRepository`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task RevokeAllExceptAsync(Guid userId, string currentSessionKey, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `userId` | `Guid` | `-` | The `userId` value passed to this member. |
| `currentSessionKey` | `string` | `-` | The `currentSessionKey` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

