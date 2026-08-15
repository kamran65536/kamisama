# IFindCurrentUser

<a id="ifindcurrentuser"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs:4](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs#L4)

Namespace: `KamiSama.Modules.Identity.Services.Users`

Kind: `Interface`

## Description

Resolves the user represented by the current execution context. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IFindCurrentUser
```

## Example

```csharp
UserDto user = await currentUser.GetCurrentUserAsync(cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [GetCurrentUserAsync](method-getcurrentuserasync-9.md) | Returns the current user. Use it with the surrounding package APIs when composing application code. |

