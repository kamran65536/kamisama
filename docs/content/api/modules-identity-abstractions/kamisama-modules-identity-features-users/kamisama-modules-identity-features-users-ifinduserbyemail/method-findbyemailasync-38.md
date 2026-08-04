# FindByEmailAsync

[Back to IFindUserByEmail](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/Users/Features.cs:38](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Users/Features.cs#L38)

Type: `KamiSama.Modules.Identity.Features.Users.IFindUserByEmail`

Kind: `Method`

## Description

Runs the `FindByEmailAsync` operation on `IFindUserByEmail`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
Task<UserDto> FindByEmailAsync(string email, CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `email` | `string` | `-` | The `email` value passed to this member. |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<UserDto>` | Returns a `Task<UserDto>` value. |

## Example

No concise standalone example is available yet.

