# PasswordValidationError

<a id="passwordvalidationerror"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Features/Password/Dtos.cs:4](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Password/Dtos.cs#L4)

Namespace: `KamiSama.Modules.Identity.Features.Password`

Kind: `Record`

## Description

Provides the `PasswordValidationError` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public record PasswordValidationError(string Code, string Description);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Features/Password/Dtos.cs#L4)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public record PasswordValidationError(string Code, string Description);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Code` | `string` | `-` | The `Code` value passed to this member. |
| `Description` | `string` | `-` | The `Description` value passed to this member. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

