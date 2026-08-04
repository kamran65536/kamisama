# ValidatePrincipal

[Back to ApplicationSessionCookieEvents](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Core](../../index.md)

Source: [src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ApplicationSessionCookieEvents.cs:10](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Core/Features/AccountSecurity/ApplicationSessionCookieEvents.cs#L10)

Type: `KamiSama.Modules.Identity.Features.AccountSecurity.ApplicationSessionCookieEvents`

Kind: `Method`

## Description

Runs the `ValidatePrincipal` operation on `ApplicationSessionCookieEvents`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public override async Task ValidatePrincipal(CookieValidatePrincipalContext context);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `context` | `CookieValidatePrincipalContext` | `-` | The `context` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task` | Returns a `Task` value. |

## Example

No concise standalone example is available yet.

