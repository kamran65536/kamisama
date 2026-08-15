# IUpdateUser

<a id="iupdateuser"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs:14](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs#L14)

Namespace: `KamiSama.Modules.Identity.Services.Users`

Kind: `Interface`

## Description

Updates the user identified by a `Guid`. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IUpdateUser : IUpdateFeature<UpdateUserRequest, Guid>;
```

## Example

```csharp
await updateUser.UpdateAsync(userId, new UpdateUserRequest("ada", "ada@example.com", "+15551234567", [KnownRoles.User]), cancellationToken);
// Core currently ignores the Roles value.
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

