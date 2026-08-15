# AddUserFailedException

<a id="adduserfailedexception"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Identity.Abstractions](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Identity.Abstractions/Exceptions/AddUserFailedException.cs:11](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Exceptions/AddUserFailedException.cs#L11)

Namespace: `KamiSama.Modules.Identity.Exceptions`

Kind: `Class`

## Description

Reports an Identity user-creation failure as HTTP 500 and retains only the first Identity error description as localization metadata.

## Declaration

```csharp
public class AddUserFailedException(string? reason) : HttpExceptionBase(nameof(AddUserFailedException), reason)
```

## Example

```csharp
try
{
    UserDto user = await addUser.AddAsync(request, cancellationToken);
}
catch (AddUserFailedException exception)
{
    logger.LogWarning(exception, "Identity rejected user creation");
}
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Identity.Abstractions/Exceptions/AddUserFailedException.cs#L11)

Represents an ASP.NET Core Identity user-creation failure and carries the first Identity error description as localization metadata. The exception reports HTTP status 500 and does not expose the remaining Identity errors.

```csharp
public class AddUserFailedException(string? reason) : HttpExceptionBase(nameof(AddUserFailedException), reason)
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `reason` | `string?` | `-` | The first Identity error description, or when no error was returned. |

## Members

### Properties

| Member | Description |
| --- | --- |
| [StatusCode](property-statuscode-14.md) | Gets the HTTP 500 status code used when user creation fails. Use it with the surrounding package APIs when composing application code. |

