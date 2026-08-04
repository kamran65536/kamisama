# FindActiveBySessionKeyAsync

[Back to IApplicationSessionRepository](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationSessionRepository.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Repositories/Abstractions/IApplicationSessionRepository.cs#L6)

Type: `KamiSama.Modules.Identity.Repositories.Abstractions.IApplicationSessionRepository`

Kind: `Method`

## Description

Runs the `FindActiveBySessionKeyAsync` operation on `IApplicationSessionRepository`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<ApplicationSession?> FindActiveBySessionKeyAsync(string sessionKey, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `sessionKey` | `string` | `-` | The `sessionKey` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<ApplicationSession?>` | Returns a `Task<ApplicationSession?>` value. |

## Example

No concise standalone example is available yet.

