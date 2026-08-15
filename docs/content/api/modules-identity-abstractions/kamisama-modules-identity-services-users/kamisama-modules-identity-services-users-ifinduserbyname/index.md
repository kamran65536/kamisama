# IFindUserByName

<a id="ifinduserbyname"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs:60](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs#L60)

Namespace: `KamiSama.Modules.Identity.Services.Users`

Kind: `Interface`

## Description

Finds a user by user name. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IFindUserByName : IFindByNameFeature<UserDto>;
```

## Example

```csharp
UserDto user = await findUserByName.FindByNameAsync("ada", cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

