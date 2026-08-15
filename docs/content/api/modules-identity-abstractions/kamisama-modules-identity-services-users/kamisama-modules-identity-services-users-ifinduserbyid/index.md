# IFindUserById

<a id="ifinduserbyid"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs:56](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs#L56)

Namespace: `KamiSama.Modules.Identity.Services.Users`

Kind: `Interface`

## Description

Finds a user by a `Guid` identifier. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IFindUserById : IFindByIdFeature<UserDto, Guid>;
```

## Example

```csharp
UserDto user = await findUserById.FindByIdAsync(userId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

