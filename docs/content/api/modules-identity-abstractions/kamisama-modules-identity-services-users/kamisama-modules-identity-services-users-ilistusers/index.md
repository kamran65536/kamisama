# IListUsers

<a id="ilistusers"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs:62](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs#L62)

Namespace: `KamiSama.Modules.Identity.Services.Users`

Kind: `Interface`

## Description

Lists users through the standard paged feature contract. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IListUsers : IListFeature<UserDto, UserSearchModel>;
```

## Example

```csharp
PagedResult<UserDto> users = await listUsers.ListAsync(new UserSearchModel(1, 20, "ada", null, null), cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

