# PasswordValidationError

<a id="passwordvalidationerror"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Password/Dtos.cs:12](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Password/Dtos.cs#L12)

Namespace: `KamiSama.Modules.Identity.Services.Password`

Kind: `Record`

## Description

Describes one password-policy validation failure. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record PasswordValidationError(string Code, string Description);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Password/Dtos.cs#L12)

Describes one password-policy validation failure. Use it with the surrounding package APIs when composing application code.

```csharp
public record PasswordValidationError(string Code, string Description);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Code` | `string` | `-` | The stable provider error code. |
| `Description` | `string` | `-` | The human-readable provider error description. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

