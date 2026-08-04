# BuildAsync

[Back to ExtendedWebApplicationBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Extensions.WebModules](../../index.md)

Source: [src/KamiSama.Extensions.WebModules/ExtendedWebApplicationBuilder.cs:69](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Extensions.WebModules/ExtendedWebApplicationBuilder.cs#L69)

Type: `KamiSama.Extensions.WebModules.ExtendedWebApplicationBuilder`

Kind: `Method`

## Description

Runs the `BuildAsync` operation on `ExtendedWebApplicationBuilder`. Use it when your code needs this specific behavior from the package.

## Declaration

```csharp
public async Task<WebApplication> BuildAsync(CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cancellationToken` | `CancellationToken` | `-` | The `cancellationToken` value passed to this member. |

## Returns

| Type | Description |
| --- | --- |
| `Task<WebApplication>` | Returns a `Task<WebApplication>` value. |

## Example

No concise standalone example is available yet.

