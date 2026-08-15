# IDeleteUser

<a id="ideleteuser"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs#L16)

Namespace: `KamiSama.Modules.Identity.Services.Users`

Kind: `Interface`

## Description

Deletes the user identified by a `Guid`. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IDeleteUser : IDeleteFeature<Guid>;
```

## Example

```csharp
await deleteUser.DeleteAsync(userId, cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

