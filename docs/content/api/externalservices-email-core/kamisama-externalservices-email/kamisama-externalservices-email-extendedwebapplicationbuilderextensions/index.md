# ExtendedWebApplicationBuilderExtensions

<a id="extendedwebapplicationbuilderextensions"></a>

[Back to namespace](../index.md) | [Back to KamiSama.ExternalServices.Email.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.ExternalServices.Email.Core/EmailCoreServicesModule.cs:41](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.ExternalServices.Email.Core/EmailCoreServicesModule.cs#L41)

Namespace: `KamiSama.ExternalServices.Email`

Kind: `Class`

## Description

Adds core email provider selection and service registrations to an `ExtendedWebApplicationBuilder`. Pass the configuration section that contains the `email` provider key.

## Declaration

```csharp
public static class ExtendedWebApplicationBuilderExtensions
```

## Example

```csharp
using KamiSama.ExternalServices.Email;
using KamiSama.Modules;

var webBuilder = WebApplication.CreateBuilder(args);
var builder = webBuilder.Extend()
    .AddCoreEmailServices(webBuilder.Configuration.GetSection("EmailDefaults"));
```

## Constructors

This type does not declare a non-private constructor in source.

## Members

### Methods

| Member | Description |
| --- | --- |
| [AddCoreEmailServices](method-addcoreemailservices-49.md) | Registers default-provider selection and the core email service implementations. Use it with the surrounding package APIs when composing application code. |

