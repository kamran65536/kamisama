# ValidatePasswordRequest

<a id="validatepasswordrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/Password/Dtos.cs:3](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Password/Dtos.cs#L3)

Namespace: `KamiSama.Modules.Identity.Features.Password`

Kind: `Record`

## Description

Provides the `ValidatePasswordRequest` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public record ValidatePasswordRequest(string? Username, string? Email, string? PhoneNumber, string Password);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Password/Dtos.cs#L3)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public record ValidatePasswordRequest(string? Username, string? Email, string? PhoneNumber, string Password);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Username` | `string?` | `-` | The `Username` value passed to this member. |
| `Email` | `string?` | `-` | The `Email` value passed to this member. |
| `PhoneNumber` | `string?` | `-` | The `PhoneNumber` value passed to this member. |
| `Password` | `string` | `-` | The `Password` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

