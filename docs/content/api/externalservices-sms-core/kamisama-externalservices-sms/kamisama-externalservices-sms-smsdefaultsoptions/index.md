# SmsDefaultsOptions

<a id="smsdefaultsoptions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Sms.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Sms.Core/SmsDefaultsOptions.cs:9](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Sms.Core/SmsDefaultsOptions.cs#L9)

Namespace: `KamiSama.ExternalServices.Sms`

Kind: `Class`

## Description

Selects the scoped keyed provider used by the unkeyed SMS dispatcher. The exact keys supplied by these packages are `mock`, `kavenegar`, and `neo-zarin`.

## Declaration

```csharp
public class SmsDefaultsOptions
```

## Example

```csharp
using KamiSama.ExternalServices.Sms;

var defaults = new SmsDefaultsOptions
{
    Sms = "mock"
};
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Properties

| Member | Description |
| --- | --- |
| [Sms](property-sms-14.md) | Gets or sets the provider key. Supported keys supplied by these packages are `mock`, `kavenegar`, and `neo-zarin`; the default is `mock`. |

