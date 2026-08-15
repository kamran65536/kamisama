# EmailDefaultsOptions

<a id="emaildefaultsoptions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Email.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Email.Core/EmailDefaultsOptions.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Core/EmailDefaultsOptions.cs#L9)

Namespace: `KamiSama.ExternalServices.Email`

Kind: `Class`

## Description

Selects the keyed email provider used by the core dispatcher. The default `mock` provider performs no delivery; set `Email` to a key registered by a transport package for another implementation.

## Declaration

```csharp
public class EmailDefaultsOptions
```

## Example

```csharp
using KamiSama.ExternalServices.Email;

var defaults = new EmailDefaultsOptions
{
    Email = "mock"
};
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [Email](property-email-14.md) | Gets or sets the keyed provider name. The built-in default is `mock`; SMTP is registered under `smtp` when its provider module is added. |

