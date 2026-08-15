# Build

[Back to ExtendedWebApplicationBuilder](index.md) | [Back to namespace](../index.md) | [Back to KamiSama.Modules](../../index.md)

Source: [src/KamiSama.Modules/ExtendedWebApplicationBuilder.cs:106](https://gitlab.com/kamran65536/KamiSama/-/blob/master/src/KamiSama.Modules/ExtendedWebApplicationBuilder.cs#L106)

Type: `KamiSama.Modules.ExtendedWebApplicationBuilder`

Kind: `Method`

## Description

Synchronously executes `BuildAsync` with `CancellationToken.None` and returns its result. Use it with the surrounding package APIs when composing application code.

## Declaration

```csharp
public WebApplication Build();
```

## Parameters

This member does not declare parameters.

## Returns

| Type | Description |
| --- | --- |
| `WebApplication` | The built and configured application. |

## Remarks

This method blocks through `Task{TResult}.Result`, so asynchronous failures are surfaced through that blocking call.

## Example

No concise standalone example is available yet.

