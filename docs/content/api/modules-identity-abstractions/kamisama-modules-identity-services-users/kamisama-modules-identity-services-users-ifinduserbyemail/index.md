# IFindUserByEmail

<a id="ifinduserbyemail"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs:74](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs#L74)

Namespace: `KamiSama.Modules.Identity.Services.Users`

Kind: `Interface`

## Description

Finds a user by email address. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IFindUserByEmail
```

## Example

```csharp
UserDto user = await findUserByEmail.FindByEmailAsync("ada@example.com", cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [FindByEmailAsync](method-findbyemailasync-80.md) | Returns the user with the supplied email address. Use it with the surrounding package APIs when composing application code. |

