# FindByNameAsync

[Back to FindUserByName](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/Users/FindUserByName.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/Users/FindUserByName.cs#L6)

Type: `KamiSama.Modules.Identity.Features.Users.FindUserByName`

Kind: `Method`

## Description

Runs the `FindByNameAsync` operation on `FindUserByName`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task<UserDto> FindByNameAsync(string username, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `username` | `string` | `-` | The `username` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<UserDto>` | Returns a `Task<UserDto>` value. |

## Example

No concise standalone example is available yet.

