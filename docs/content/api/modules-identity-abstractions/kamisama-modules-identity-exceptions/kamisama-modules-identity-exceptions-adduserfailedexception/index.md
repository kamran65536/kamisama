# AddUserFailedException

<a id="adduserfailedexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Exceptions/AddUserFailedException.cs:6](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Exceptions/AddUserFailedException.cs#L6)

Namespace: `KamiSama.Modules.Identity.Exceptions`

Kind: `Class`

## Description

Provides the `AddUserFailedException` API for the surrounding package. Use this type with the members listed below to compose the feature in an application.

## Declaration

```csharp
public class AddUserFailedException(string? reason) : HttpExceptionBase(nameof(AddUserFailedException), reason)
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Exceptions/AddUserFailedException.cs#L6)

Initializes the type with the values required by its declaration. Use it with the surrounding package APIs when composing application code.

```csharp
public class AddUserFailedException(string? reason) : HttpExceptionBase(nameof(AddUserFailedException), reason)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `reason` | `string?` | `-` | The `reason` value passed to this member. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [StatusCode](property-statuscode-8.md) | Exposes the `StatusCode` value on `AddUserFailedException`. Read or set it as part of configuring or using the type. |

