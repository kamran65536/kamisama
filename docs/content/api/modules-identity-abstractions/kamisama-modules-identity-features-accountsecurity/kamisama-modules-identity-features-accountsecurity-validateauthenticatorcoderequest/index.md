# ValidateAuthenticatorCodeRequest

<a id="validateauthenticatorcoderequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/AccountSecurity/Dtos.cs:17](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/AccountSecurity/Dtos.cs#L17)

Namespace: `KamiSama.Modules.Identity.Features.AccountSecurity`

Kind: `Record`

## Description

Provides the `ValidateAuthenticatorCodeRequest` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public record ValidateAuthenticatorCodeRequest(
	Guid UserId,
	string AuthenticatorCode);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/AccountSecurity/Dtos.cs#L17)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public record ValidateAuthenticatorCodeRequest(
	Guid UserId,
	string AuthenticatorCode);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `UserId` | `Guid` | `-` | The `UserId` value passed to this member. |
| `AuthenticatorCode` | `string` | `-` | The `AuthenticatorCode` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

