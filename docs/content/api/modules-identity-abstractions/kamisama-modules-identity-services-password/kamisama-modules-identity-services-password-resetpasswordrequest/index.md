# ResetPasswordRequest

<a id="resetpasswordrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Password/Dtos.cs:16](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Password/Dtos.cs#L16)

Namespace: `KamiSama.Modules.Identity.Services.Password`

Kind: `Record`

## Description

Supplies an identity lookup value and replacement password to a reset implementation. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record ResetPasswordRequest(string Identity, string Password);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Password/Dtos.cs#L16)

Supplies an identity lookup value and replacement password to a reset implementation. Use it with the surrounding package APIs when composing application code.

```csharp
public record ResetPasswordRequest(string Identity, string Password);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Identity` | `string` | `-` | The user name or email address interpreted by the implementation. |
| `Password` | `string` | `-` | The replacement password. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

