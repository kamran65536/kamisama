# FindByIdAsync

[Back to FindUserById](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/FindUserById.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/FindUserById.cs#L6)

Type: `KamiSama.Modules.Identity.Features.Users.FindUserById`

Kind: `Method`

## Description

Runs the `FindByIdAsync` operation on `FindUserById`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task<UserDto> FindByIdAsync(Guid id, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `id` | `Guid` | `-` | The `id` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<UserDto>` | Returns a `Task<UserDto>` value. |

## Example

No concise standalone example is available yet.

