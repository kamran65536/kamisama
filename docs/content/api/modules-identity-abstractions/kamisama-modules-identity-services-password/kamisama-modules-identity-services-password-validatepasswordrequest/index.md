# ValidatePasswordRequest

<a id="validatepasswordrequest"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Services/Password/Dtos.cs:8](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Password/Dtos.cs#L8)

Namespace: `KamiSama.Modules.Identity.Services.Password`

Kind: `Record`

## Description

Supplies optional identity context and a candidate password for policy validation. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public record ValidatePasswordRequest(string? Username, string? Email, string? PhoneNumber, string Password);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Services/Password/Dtos.cs#L8)

Supplies optional identity context and a candidate password for policy validation. Use it with the surrounding package APIs when composing application code.

```csharp
public record ValidatePasswordRequest(string? Username, string? Email, string? PhoneNumber, string Password);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `Username` | `string?` | `-` | An optional user name used to create validation context. |
| `Email` | `string?` | `-` | An optional email address used to create validation context. |
| `PhoneNumber` | `string?` | `-` | An optional phone number used to create validation context. |
| `Password` | `string` | `-` | The candidate password. |

## Members

No non-private methods, properties, fields, events, operators, or enum values are declared directly on this type.

