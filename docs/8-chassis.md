# KamiSama.Chassis
The Chassis collection is a set of lightweight extensions on AspNetCore that helps you to write less code and gain more productivity.


## KamiSama.Chassis.HttpExceptions
Set of exception classes inherited from HttpExceptionBase.
These classes provide some default information and also can be used along with KamiSama.Chassis.ProblemDetails.

## KamiSama.Chassis.ProblemDetails

The library is based on Microsoft AspNetCore ProblemDetails 
and helps you to handle errors in a more standardized manner.

To Setup you should add the following code to your project:
```csharp
//in Program.cs or Startup.cs

builder.Services.AddProblemDetails();
builder.Services
	.AddControllers()
	.AddExceptionFilterForProblemDetails();
```
### Customization
You can also customize the conversion of problem details:
```csharp
builder.Services.AddProblemDetails();
builder.Services
	.AddControllers()
	.AddExceptionFilterForProblemDetails(opt => opt.UseProblemDetailsProvider(sp => new CustomProvider()));
```

That's easy!

### Localization
The KamiSama Chassis problem details library supports localization. In order to use, you can define your own Resources.resx 
and use it in alongside the problem details. You need to add localization separately.

```csharp
builder.Services.AddProblemDetails();
builder.Services
	.AddControllers()
    .AddExceptionFilterForProblemDetails(opt => opt.UseResourceLocalizer<CustomResources>());
builder.Services.AddLocalization(); // adding localization
```