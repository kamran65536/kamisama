# IAddUser

<a id="iadduser"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs#L12)

Namespace: `KamiSama.Modules.Identity.Services.Users`

Kind: `Interface`

## Description

Creates a user through the standard add-feature contract. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IAddUser : IAddFeature<AddUserRequest, UserDto>;
```

## Example

```csharp
UserDto user = await addUser.AddAsync(new AddUserRequest("ada", "ada@example.com", "+15551234567", password, true, [KnownRoles.User]), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

