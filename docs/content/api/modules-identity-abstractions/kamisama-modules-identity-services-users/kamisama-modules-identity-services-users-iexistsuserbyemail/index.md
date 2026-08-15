# IExistsUserByEmail

<a id="iexistsuserbyemail"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs:65](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Users/Features.cs#L65)

Namespace: `KamiSama.Modules.Identity.Services.Users`

Kind: `Interface`

## Description

Checks whether a user exists for an email address. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public interface IExistsUserByEmail
```

## Example

```csharp
bool exists = await existsUserByEmail.ExistsAsync("ada@example.com", cancellationToken);
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [ExistsAsync](method-existsasync-71.md) | Returns whether a user has the supplied email address. Use it with the surrounding package APIs when composing application code. |

