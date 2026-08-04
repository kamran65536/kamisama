# DisableUserAsync

[Back to DisableUser](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/DisableUser.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/DisableUser.cs#L8)

Type: `KamiSama.Modules.Identity.Features.Users.DisableUser`

Kind: `Method`

## Description

Runs the `DisableUserAsync` operation on `DisableUser`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task DisableUserAsync(Guid userId, CancellationToken cancellationToken);
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

