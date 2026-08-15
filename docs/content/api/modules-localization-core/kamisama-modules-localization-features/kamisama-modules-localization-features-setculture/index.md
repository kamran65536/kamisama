# SetCulture

<a id="setculture"></a>

[Back to namespace](../index.md) | [Back to KamiSama.Modules.Localization.Core](../../index.md) | [Back to package index](../../../index.md)

Source: [src/KamiSama.Modules.Localization.Core/Features/SetCulture.cs:13](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/Features/SetCulture.cs#L13)

Namespace: `KamiSama.Modules.Localization.Features`

Kind: `Class`

## Description

Validates configured culture metadata and appends a one-year request-culture cookie to the active response. It requires `AddHttpContextAccessor`, affects a later request, and ignores cancellation.

## Declaration

```csharp
public class SetCulture(IOptions<LocalizationOptions> options, IHttpContextAccessor httpContextAccessor) : ISetCulture
```

## Example

```csharp
webBuilder.Services.AddHttpContextAccessor();
// Resolve ISetCulture in an active request, then append a cookie for a later request.
CultureInfoDto selected = await setCulture.SetAsync("fa-IR", CancellationToken.None);
```

## Constructors

### Primary constructor

[source](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules.Localization.Core/Features/SetCulture.cs#L13)

Validates a culture against configured metadata and appends ASP.NET Core&apos;s request-culture cookie to the active response. The cookie affects culture selection on a later request and does not change the current request&apos;s culture.

```csharp
public class SetCulture(IOptions<LocalizationOptions> options, IHttpContextAccessor httpContextAccessor) : ISetCulture
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `options` | `IOptions<LocalizationOptions>` | `-` | The bound localization options containing supported culture metadata. |
| `httpContextAccessor` | `IHttpContextAccessor` | `-` | The accessor used to obtain the active response; applications must register it with `AddHttpContextAccessor`. |

## Members

### Methods

| Member | Description |
| --- | --- |
| [SetAsync](method-setasync-23.md) | Finds a configured culture by case-insensitive name, requires an active HTTP context, and appends a request-culture cookie that expires in one year. Use it with the surrounding package APIs when composing application code. |

