# RefreshAccessTokenResponse

<a id="refreshaccesstokenresponse"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/Users/Dtos.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Users/Dtos.cs#L10)

Namespace: `KamiSama.Modules.Identity.Features.Users`

Kind: `Record`

## Description

Provides the `RefreshAccessTokenResponse` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public record RefreshAccessTokenResponse(string AccessToken, string RefreshToken);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Users/Dtos.cs#L10)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public record RefreshAccessTokenResponse(string AccessToken, string RefreshToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `AccessToken` | `string` | `-` | The `AccessToken` value passed to this member. |
| `RefreshToken` | `string` | `-` | The `RefreshToken` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

