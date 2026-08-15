# BuildAsync

[Back to ExtendedWebApplicationBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/ExtendedWebApplicationBuilder.cs:89](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ExtendedWebApplicationBuilder.cs#L89)

Type: `KamiSama.Modules.ExtendedWebApplicationBuilder`

Kind: `Method`

## Description

Runs every module&apos;s service phase in insertion order, builds the application once, then awaits every module&apos;s application phase in the same order. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public async Task<WebApplication> BuildAsync(CancellationToken cancellationToken);
```

## Parameters

| Name | Type | Default | Description |
| --- | --- | --- | --- |
| `cancellationToken` | `CancellationToken` | `-` | The token passed to each post-build module; the underlying synchronous build does not observe it. |

## Returns

| Type | Description |
| --- | --- |
| `Task<WebApplication>` | The built and configured application. |

## Remarks

An exception in either phase stops processing; later modules are not invoked. Calling this method more than once attempts to build the same underlying builder again.

## Example

No concise standalone example is available yet.

